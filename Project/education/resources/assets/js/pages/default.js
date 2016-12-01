$('.category1').click(function () {
    $('.sub-category1').toggleClass('open');
    $('.sub-category1').toggle();
    var $this = $(this);
    if ($('.sub-category1').hasClass('open')) {
        $this.find('i.fa-angle-up').addClass('hide');        
        $this.find('i.fa-angle-down').removeClass('hide');
    }else{
        $this.find('i.fa-angle-up').removeClass('hide');        
        $this.find('i.fa-angle-down').addClass('hide');
    }
});
$('.category2').click(function () {
    $('.sub-category2').toggleClass('open');
    $('.sub-category2').toggle();
    var $this = $(this);
    if ($('.sub-category2').hasClass('open')) {
        $this.find('i.fa-angle-up').removeClass('hide');        
        $this.find('i.fa-angle-down').addClass('hide');
    }else{
        $this.find('i.fa-angle-up').addClass('hide');        
        $this.find('i.fa-angle-down').removeClass('hide');
    }
});