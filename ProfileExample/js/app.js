$('#btnTest').click(function() {
    const decTaxRate = .0925;
    let decHours = $('#txtHours').val();
    let decRate = $('#txtPayRate').val();
    console.log(decHours * decRate);
});
$('#cboEmployeeType').change(function() {
    if($('#cboEmployeeType').val()== 'FULL'){
        //$('divHours').slideup();
        //$('divHours').css('display','none')
        $('divHours').addClass('b-none','none')
    }else {
        $('divHours').slideDown();
    }
}