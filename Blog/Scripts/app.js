$(function () {
    $.material.init();

    $("#saveHistory").click(function(){
        var url = $("#history").attr("action");
        
        $.post(url, $("#history").serialize(), function (result) {
            showHistories();
        }).error(function (result) {
            console.log(result);
        });
        return false;
    });

    $("#savePost").click(function () {
        var url = $("#post").attr("action");
        var id = $(this).data('unique');
        $.post(url, $("#post").serialize(), function (result) {
            showPosts(id);
        }).error(function (result) {
            console.log(result);
        });
        return false;
    });
    
    function showHistories(){
        $.get("/Home/List", {}, function (html) {
            $("#histories").children().remove();
            $("#histories").append(html);
        });
    }
    function showPosts(id) {
        $.get("/Home/PostsList", { id:id }, function (html) {
            $("#posts").children().remove();
            $("#posts").append(html);
        });
    }
}(jQuery));