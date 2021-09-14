$('btnCalculate').click(function(){
    let decHourlyRate = $('txtHourlyRate').val();
    let decHoursWorked = $('txtHoursWorked').val();
    console.log(decHourlyRate * decHoursWorked);

})