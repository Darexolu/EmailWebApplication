$(document).ready(function () {
    
    $file = $("#fileId");
    var $filePath = $.trim($file.val());
  
    if ($filePath == "") {
        alert("Please browse an image file to upload(jpg,png,jpeg only)");
        return;
    }
//    var $ext = $filePath.split(".").pop().toLowerCase();
//    var $allow = new Array("png", "jpg", "jpeg");
//     if ($.inArray($ext, $allow) == -1) {
//        alert("Only image files are accepted, please browse an image file");
//        return;
//}

});
