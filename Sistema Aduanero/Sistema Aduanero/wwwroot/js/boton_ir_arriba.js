$(document).ready(function(){
    $('.ir_arriba').click(function(){
        $('body, html').animate({
            scrollTop:'0px'
        },300);
    });

    $(window).scroll(function(){
        if($(this).scrollTop() > 0){
            $('.ir_arriba').slideDown(300);
        }else{
            $('.ir_arriba').slideUp(300);
        }
    });
});