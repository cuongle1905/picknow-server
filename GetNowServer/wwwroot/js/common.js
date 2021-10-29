function nonAccentVietnamese(str) {
    str = str.toLowerCase();
    //     We can also use this instead of from line 11 to line 17
    //     str = str.replace(/\u00E0|\u00E1|\u1EA1|\u1EA3|\u00E3|\u00E2|\u1EA7|\u1EA5|\u1EAD|\u1EA9|\u1EAB|\u0103|\u1EB1|\u1EAF|\u1EB7|\u1EB3|\u1EB5/g, "a");
    //     str = str.replace(/\u00E8|\u00E9|\u1EB9|\u1EBB|\u1EBD|\u00EA|\u1EC1|\u1EBF|\u1EC7|\u1EC3|\u1EC5/g, "e");
    //     str = str.replace(/\u00EC|\u00ED|\u1ECB|\u1EC9|\u0129/g, "i");
    //     str = str.replace(/\u00F2|\u00F3|\u1ECD|\u1ECF|\u00F5|\u00F4|\u1ED3|\u1ED1|\u1ED9|\u1ED5|\u1ED7|\u01A1|\u1EDD|\u1EDB|\u1EE3|\u1EDF|\u1EE1/g, "o");
    //     str = str.replace(/\u00F9|\u00FA|\u1EE5|\u1EE7|\u0169|\u01B0|\u1EEB|\u1EE9|\u1EF1|\u1EED|\u1EEF/g, "u");
    //     str = str.replace(/\u1EF3|\u00FD|\u1EF5|\u1EF7|\u1EF9/g, "y");
    //     str = str.replace(/\u0111/g, "d");
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    // Some system encode vietnamese combining accent as individual utf-8 characters
    str = str.replace(/\u0300|\u0301|\u0303|\u0309|\u0323/g, ""); // Huyền sắc hỏi ngã nặng
    str = str.replace(/\u02C6|\u0306|\u031B/g, ""); // Â, Ê, Ă, Ơ, Ư
    return str;
}
var columnNameForConvertedText = "Name";
function filterTextVN(filterValue, selectedFilterOperation, columnName) {
    filterValue = nonAccentVietnamese(filterValue);
    if (columnName == undefined)
        columnNameForConvertedText = "Name";
    else
        columnNameForConvertedText = columnName;

    return [getConvertedTextForColumn, selectedFilterOperation || "contains", filterValue];
}
function getConvertedTextForColumn(rowData) {
    return nonAccentVietnamese(rowData[columnNameForConvertedText]);
}

function getDataSource(dataSource, category, url, filterAttribute, optionsData) {
    console.log("getDataSource for " + category);
    if (dataSource[category] == undefined) {
        console.log("Load " + category + " from server.");
        return {
            store: DevExpress.data.AspNet.createStore({
                key: "Id",
                loadMode: "raw",
                cacheRawData: true,
                loadUrl: url,
                onLoaded: function (result) {
                    console.log("Receive " + category + " from server: " + result.length);
                    addNameSearchColumn(result);
                    dataSource[category] = result;
                }
            })
        };
    } else {
        console.log("Load " + category + " from client.");
        return optionsData ? dataSource[category].filter(d => d[filterAttribute] == optionsData[filterAttribute]) : dataSource[category];
    }
}
function addNameSearchColumn(data) {
    if (data.length == 0 || data[0]["Name"] == undefined)
        return;

    data.forEach(function (item) {
        var name = item["Name"];
        var name2 = nonAccentVietnamese(name);
        //console.log("addNonAccentColumn: " + name + " -> " + name2)
        item["NameSearch"] = name2 + "; " + name;
    });
}
function numberWithCommas(x) {
    return x.toString().replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, ",");
}

function createDxFileUploader(uploadUrl, fileUploaderId, popupContainerId) {
    if (fileUploaderId == undefined)
        fileUploaderId = "#changeIconFileUploader";

    if (popupContainerId == undefined)
        popupContainerId = "#changeIconPopoverContainer";

    $(fileUploaderId).dxFileUploader({
        multiple: false,
        accept: "*",
        value: [],
        name: "myFile1",
        uploadMode: "instantly",
        uploadUrl: uploadUrl,
        allowedFileExtensions: [".png", ".jpg", ".jpeg"],
        minFileSize: 128,
        maxFileSize: 1024 * 1024,
        onUploaded: function (e) {
            $("#changeIconPopoverContainer").dxPopover("hide");
            var fileUploader = e.component;
            fileUploader.reset();
            var name = fileUploader.option("name");
            var dataId = name.replace("myFile", "");
            var img = document.getElementById("itemImg" + dataId);
            img.src = "/data_images/" + e.request.responseText;
            console.log("Uploaded image");
            console.log(e.request.responseText);
        }
    });

    $(popupContainerId).dxPopover({
        target: "#itemImgLink1",
        showEvent: "dxclick",
        position: "top",
        width: 400,
        title: "Change Icon:",
        showTitle: true,
        showCloseButton: true,
        shading: true,
        shadingColor: "rgba(0, 0, 0, 0.5)"
    });

    $("#removeIconButton").dxButton({
        stylingMode: "contained",
        text: "Remove Icon",
        type: "danger",
        width: 160,
        onClick: function () {
            $.ajax({
                url: '@Url.Action("Remove", "Upload")',
                data: { dataId: $("#removeIconButton").attr("dataId") },
                dataType: "text",
                type: "POST",
                success: function (response) {
                    $("#changeIconPopoverContainer").dxPopover("hide");
                    var dataId = $("#removeIconButton").attr("dataId");
                    var img = document.getElementById("itemImg" + dataId);
                    img.src = "";
                },
                failure: function (response) {
                    alert("failure " + response.responseText);
                },
                error: function (response) {
                    alert("error " + response.responseText);
                }
            });
        }
    });
}

function showChangeIconPopover(dataId, fileUploaderId, popupContainerId) {
    if (fileUploaderId == undefined)
        fileUploaderId = "#changeIconFileUploader";

    if (popupContainerId == undefined)
        popupContainerId = "#changeIconPopoverContainer";

    $(popupContainerId).dxPopover("show", "#itemImgLink" + dataId);
    var fileUploader = $(fileUploaderId).dxFileUploader("instance");
    fileUploader.option("name", "myFile" + dataId);

    var img = document.getElementById("itemImg" + dataId);
    if (img.complete && img.naturalHeight !== 0) {
        //alert("hi");
        $("#removeIconButton").dxButton("instance").option("visible", true);
        $("#removeIconButton").attr("dataId", dataId);
    } else {
        //alert("bye");
        $("#removeIconButton").dxButton("instance").option("visible", false);
    }
}

(function ($) {
    $.fn.descendantOf = function (parentId) {
        return this.closest(parentId).length > 0;
    }
})(jQuery)

function getName(itemId, items) {
    for (item of items) {
        if (item.Id == itemId)
            return item.Name;
    }
    return "";
}