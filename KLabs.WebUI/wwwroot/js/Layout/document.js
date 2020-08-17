function downloadPdfFromBase64(data,name) {

    var linkSource = data;
    var downloadLink = document.createElement("a");
    var fileName = name+".pdf";
    downloadLink.href = linkSource;
    downloadLink.download = fileName;
    downloadLink.click();

}