$.getJSON("https://www.swollenhippo.com/getEmployeesByAPIKey.php?APIKey=Mickey2021!"), function(result){
    console.log(result);
    arrEmployees = result;
    buildEmployeeCar();
    $.each(result,function(i,person){
        $('#txtEmail').val(person.Email);
    })
}

function buildEmployeeCard (){
    $.each(arrEmployees,function(i,person){
        let strHTML = '<div class="divCardContainer">';
        strHTML += '<div class="card col-4 offset-4 mt-5">';
        strHTML += '<h1 class="text-center mt-3">First Name</h1>';
        strHTML += '<h1 class="text-center">' + person.Position + '</h1>';
        strHTML += '<h2>Profile details</h2>';
        strHTML += '<h3>HireDate ' + person.Hiredate +' </h3';
        strHTML += '<p>HourlyRate '+ person.HourlyRate +'</p>';
        strHTML += '<div class="form-group">';
        strHTML += '<label id="txtEmail" for="txtEmail" class="form-label">Email</label>';
        strHTML += '<input type="email" class="form-control" id="txtEmail" placeholder="John.Doe@gmail.com">';
        strHTML += '</div>';
        strHTML += '<div class="form-group">';
        strHTML += '<label id="txtHourlyRate" for="txtHourlyRate">Hourly Rate</label>';
        strHTML += '<input type="HourlyRate" class="form-control" id="txtHourlyRate" placeholder="$10 per hour">';
        strHTML += '</div>';
        strHTML += '<div class="form-group">';
        strHTML += '<label id="textHoursWorked" for="txtHoursWorked">Hours Worked</label>';
        strHTML += '<input type="HoursWorked" class="form-control" id="txtHoursWorked">';
        strHTML += '</div>';
        strHTML += '<div>';
        strHTML += '<input class="mb-3" id="btnCalculate" disabled>';
        strHTML += '<button type="button" id="btnCalculate" class="btn btn-primary mb-3">Calculate</button>';
        strHTML += '</div>';
        strHTML += '</div>';
        strHTML += '</div>';    
        $('body').append(strHTML);
        $('#tblEmployees tbody').append('<tr><td>' + person.FirstName + '</td><td>' + person.LastName +'</td></tr>');
    })
    $('#tblEmployees').DataTable();

}

$('btnCalculate').click(function(){
    let decHourlyRate = $('#txtHourlyRate').val();
    let decHoursWorked = $('#txtHoursWorked').val();
    console.log(decHourlyRate * decHoursWorked);
})