$(document).ready(function () {
    var showEndpoints = true;


    var clickedLink = sessionStorage.getItem("clickedLink");

    
    /**Navigation to swagger from documentation pages  */
    if(clickedLink == null)
    {
        $('#about').addClass("current");
        $('.endpoint-definitions').css("display", "block");

    }
     if(clickedLink == 1) 
    {
        $('#about').addClass("current");
        $('#endpoints').removeClass("current");
        $('#models').removeClass("current");
        $('.endpoint-definitions').css("display", "block");
        $('#endpoints-title').css("display", "none");

    }
    else if(clickedLink == 2)
    {        
        $('#endpoints').addClass("current");
        $('#about').removeClass("current");
        $('#models').removeClass("current");
        $('.endpoint-definitions').css("display", "none");
        $('#endpoints-title').css("display", "block");
    }
    else if(clickedLink == 3)
    {
        
        $('#models').addClass("current");
        $('#endpoints').removeClass("current");
        $('#about').removeClass("current");
        $('.endpoint-definitions').css("display", "none");
        $('#endpoints-title').css("display", "none");

    }
    /**delay added to give swagger generated items time */
    setTimeout(function(){
         if(clickedLink == 1) 
        {
            $('.opblock-tag').css("display", "none");
            $('.opblock-get').css("display", "none");
            $('.opblock-put').css("display", "none");
            $('.opblock-post').css("display", "none");
            $('.models').css("display", "none");
            $('#endpoints-title').css("display", "none");

        }
        else if(clickedLink == 2)
        {        
            $('.opblock-tag').css("display", "block");
            $('.opblock-get').css("display", "block");
            $('.opblock-put').css("display", "block");
            $('.opblock-post').css("display", "block");
            $('.models').css("display", "none");
            $('#endpoints-title').css("display", "block");

        }
        else if(clickedLink == 3)
        {
            $('.opblock-tag').css("display", "none");
            $('.opblock-get').css("display", "none");
            $('.opblock-put').css("display", "none");
            $('.opblock-post').css("display", "none");
            $('.models').css("display", "block");
            $('#endpoints-title').css("display", "none");

        }

     }, 500);

   

    /**Navigation within swagger page */
    $('#endpoints').click(function () {
        sessionStorage.setItem("clickedLink", 2);
        $('#endpoints').addClass("current");
        $('#about').removeClass("current");
        $('#models').removeClass("current");
        $('.opblock-tag').css("display", "block");
        $('.opblock-get').css("display", "block");
        $('.opblock-put').css("display", "block");
        $('.opblock-post').css("display", "block");
        $('.models').css("display", "none");
        $('.endpoint-definitions').css("display", "none");
        $('#endpoints-title').css("display", "block");


    });
    $('#models').click(function () {
        sessionStorage.setItem("clickedLink", 3);
        $('#models').addClass("current");
        $('#endpoints').removeClass("current");
        $('#about').removeClass("current");

        $('.opblock-tag').css("display", "none");
        $('.opblock-get').css("display", "none");
        $('.opblock-put').css("display", "none");
        $('.opblock-post').css("display", "none");
        $('.models').css("display", "block");
        $('.endpoint-definitions').css("display", "none");
        $('#endpoints-title').css("display", "none");


    });
    $('#about').click(function () {
        sessionStorage.setItem("clickedLink", 1);
        $('#about').addClass("current");
        $('#endpoints').removeClass("current");
        $('#models').removeClass("current");

        $('.opblock-tag').css("display", "none");
        $('.opblock-get').css("display", "none");
        $('.opblock-put').css("display", "none");
        $('.opblock-post').css("display", "none");
        $('.models').css("display", "none");
        $('.endpoint-definitions').css("display", "block");
        $('#endpoints-title').css("display", "none");


    });

    $('#operations-tag-Deduction').click(function () {
        if (showEndpoints) {

            showEndpoints = false;
            $('.opblock-tag').css("display", "none");
            $('.opblock-get').css("display", "none");
            $('.opblock-put').css("display", "none");
            $('.opblock-post').css("display", "none");
            $('#endpoints-title').css("display", "none");

        } else {
            showEndpoints = true;
            $('.opblock-tag').css("display", "block");
            $('.opblock-get').css("display", "block");
            $('.opblock-put').css("display", "block");
            $('.opblock-post').css("display", "block");
            $('#endpoints-title').css("display", "block");

        }
    });
});