tinymce.init({
    selector: 'textarea[data-tiny]',
    plugins: 'advlist autolink lists link image charmap preview anchor pagebreak',
    toolbar_mode: 'floating',
});

function newPost() {
    document.frmNewPost.submit();
}