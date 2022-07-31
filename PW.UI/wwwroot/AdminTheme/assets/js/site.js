
var SinglePage = {};

SinglePage.LoadModal = function () {
    var url = window.location.hash.toLowerCase();
    if (!url.startsWith("#showmodal")) {
        return;
    }
    url = url.split("showmodal=")[1];
    $.get(url,
        null,
        function (htmlPage) {
            $("#ModalContent").html(htmlPage);
            const container = document.getElementById("ModalContent");
            const forms = container.getElementsByTagName("form");
            const newForm = forms[forms.length - 1];
            $.validator.unobtrusive.parse(newForm);
            showModal();
        }).fail(function (error) {
            alert("خطایی رخ داده، لطفا با مدیر سیستم تماس بگیرید.");
        });
};

function showModal() {
    $("#MainModal").modal("show");
}

function hideModal() {
    $("#MainModal").modal("hide");
}

$(document).ready(function () {
    window.onhashchange = function () {
        SinglePage.LoadModal();
    };
    $("#MainModal").on("shown.bs.modal",
        function () {
            window.location.hash = "##";
            $('.datepicker').datepicker({
                autoclose: true
            });
        });

    $(document).on("submit",
        'form[data-ajax="true"]',
        function (e) {
            e.preventDefault();
            var form = $(this);
            const method = form.attr("method").toLocaleLowerCase();
            const url = form.attr("action");
            var action = form.attr("data-action");

            if (method === "get") {
                const data = form.serializeArray();
                $.get(url,
                    data,
                    function (data) {
                        CallBackHandler(data, action, form);
                    });
            } else {
                var formData = new FormData(this);
                $.ajax({
                    url: url,
                    type: "post",
                    data: formData,
                    enctype: "multipart/form-data",
                    dataType: "json",
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        CallBackHandler(data, action, form);
                    },
                    error: function (data) {
                        alert("خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.");
                    }
                });
            }
            return false;
        });
});

function CallBackHandler(data, action, form) {
    switch (action) {
        case "Message":
            alert(data.Message);
            break;
        case "Refresh":
            if (data.isSuccessful) {
                alert(data.message);
                window.location.reload();
            } else {
                alert(data.message);
            }
            break;
        case "RefereshList":
            {
                hideModal();
                const refereshUrl = form.attr("data-refereshurl");
                const refereshDiv = form.attr("data-refereshdiv");
                get(refereshUrl, refereshDiv);
            }
            break;
        case "setValue":
            {
                const element = form.data("element");
                $(`#${element}`).html(data);
            }
            break;
        default:
    }
}

function get(url, refereshDiv) {
    const searchModel = window.location.search;
    $.get(url,
        searchModel,
        function (result) {
            $("#" + refereshDiv).html(result);
        });
}

function FillSerializeDropdown(source, action, dist) {
    $('#' + dist).empty();
    var selectedId = $('#' + source).find("option:selected").val();
    $.getJSON('?handler=' + action + '&Id=' + selectedId, function (data) {
        $.each(data, function (key, parentlist) {
            //$('select#' + dist).append('<option value="0">Select One</option>');
            // loop through the TM Managers and fill the dropdown
            //$.each(parentlist, function (index, parent) {
            $('select#' + dist).append(
                '<option value="' + parentlist.id + '">'
                + parentlist.title +
                '</option>');
            //});
        });
    });

    //$.ajax({
    //    url: '?handler='+action + '/'+selectedId,
    //    type: 'GET',
    //    data: JSON.stringify({ Id: selectedId }),
    //    dataType: 'json',
    //    contentType: "application/json; charset=utf-8",
    //    success: function (data) {
    //        $.each(data, function (key, parentlist) {
    //            $('select#' + dist).append('<option value="0">Select One</option>');
    //            // loop through the TM Managers and fill the dropdown
    //            $.each(parentlist, function (index, parent) {
    //                $('select#' + dist).append(
    //                    '<option value="' + parent.Id + '">'
    //                    + parent.Title +
    //                    '</option>');
    //            });
    //        });
    //    }
    //});


    //$.getJSON('@Url.Action("handler=?"' + action + '")', { id: selectedId }, function (data) {
    //$('#' + dist).empty();
    //$.each(data, function (i) {
    //    var option = $('<option></option>').attr("value", data[i].Id).text(data[i].Title);
    //    $("#" + dist + '"').append(option);
    //});
    //});


    //$.get(action + '/' + selectedId).done(function (parentlist) {
    //    $.each(parentlist, function (i, parent) {
    //        $('select#' + dist).append('<option value="0">Select One</option>');
    //        // loop through the TM Managers and fill the dropdown
    //        $.each(parentlist, function (index, parent) {
    //            $('select#' + dist).append(
    //                '<option value="' + parent.Id + '">'
    //                + parent.Title +
    //                '</option>');
    //        });
    //    });
    //});
}


function UpdatePermissionListByModule(source, action, dist) {
    //$('#' + dist).empty();
    var selectedId = $('#' + source).find("option:selected").val();
    //$.get('?handler=' + action + '&Id=' + selectedId);


    $.ajax({
        url: '?handler=' + action + '&Id=' + selectedId,
        type: "get",
        //data: formData,
        success: function () {
            $('#' + dist).location.reload();
            //alert("Hello: .\nCurrent Date and Time: " + response.DateTime);
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function SetSlug(source, dist) {
    //$('#' + source).change(function () {
    $('#' + dist).val('');
    var selectedText = $('#' + source).find("option:selected").text();
    $('#' + dist).val($('#' + dist).val() + '-' + convertToSlug(selectedText));
};

function makeSlug(source1, source2, dist) {

    var selectedText = "";
    var value = "";
    if ($('#' + source1).val() != null) {
        value = $('#' + source1).val();
    };
    if ($('#' + source2).val() > 0) {
        selectedText = $('#' + source2).find("option:selected").text();
    };
    var slugtext = value + " " + selectedText;
    $('#' + dist).val(convertToSlug(slugtext));

}

var convertToSlug = function (str) {
    var $slug = '';
    const trimmed = $.trim(str);
    $slug = trimmed.replace(/[^a-z0-9-آ-ی-]/gi, '-').replace(/-+/g, '-').replace(/^-|-$/g, '');
    return $slug.toLowerCase();
};

function checkSlugDuplication(url, dist) {
    const slug = $('#' + dist).val();
    const id = convertToSlug(slug);
    $.get({
        url: url + '/' + id,
        success: function (data) {
            if (data) {
                sendNotification('error', 'top right', "خطا", "اسلاگ نمی تواند تکراری باشد");
            }
        }
    });
}

function fillField(source, dist) {
    const value = $('#' + source).val();
    $('#' + dist).val(value);
}

function getSetIdValue(sourcefield1, sourcevalue1, sourcefield2, sourcevalue2, dist1, dist2, cnt) {
    var hand1 = "?handler=" + dist1;
    var hand2 = "?handler=" + dist2;

    var f1 = "&" + sourcefield2 + '=' + $('#' + sourcevalue2).val();
    var f2 = "&" + sourcefield1 + '=' + $('#' + sourcevalue1).val();

    var sourcevalue2 = $('#' + sourcefield2).val();
    //output = $('#' + dist).val($('#' + dist).val('href') + output);
    $('#' + dist1).attr('href', hand1 + f1 + f2);
    $('#' + dist2).attr('href', hand2 + f1 + f2);

}

$(document).on("click",
    'button[data-ajax="true"]',
    function () {
        const button = $(this);
        const form = button.data("request-form");
        const data = $(`#${form}`).serialize();
        let url = button.data("request-url");
        const method = button.data("request-method");
        const field = button.data("request-field-id");
        if (field !== undefined) {
            const fieldValue = $(`#${field}`).val();
            url = url + "/" + fieldValue;
        }
        if (button.data("request-confirm") == true) {
            if (confirm("آیا از انجام این عملیات اطمینان دارید؟")) {
                handleAjaxCall(method, url, data);
            }
        } else {
            handleAjaxCall(method, url, data);
        }
    });

function handleAjaxCall(method, url, data) {
    if (method === "post") {
        $.post(url,
            data,
            "application/json; charset=utf-8",
            "json",
            function (data) {

            }).fail(function (error) {
                alert("خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.");
            });
    }
}

//jQuery.validator.addMethod("maxFileSize",
//    function (value, element, params) {
//        var size = element.files[0].size;
//        var maxSize = 3 * 1024 * 1024;
//        if (size > maxSize)
//            return false;
//        else {
//            return true;
//        }
//    });
//jQuery.validator.unobtrusive.adapters.addBool("maxFileSize");

jQuery.validator.addMethod("FileExtentionLimitation",
    function (value, element, params) {
        debugger;
        var extention = element.files[0].extention;
        debugger;
        var validextentions = new Array(".jpeg", ".png", ".jpg");
        if (jQuery.inArray(extention, validextentions))
            return true;
        else {
            return false;
        }
    });
jQuery.validator.unobtrusive.adapters.addBool("FileExtentionLimitation");