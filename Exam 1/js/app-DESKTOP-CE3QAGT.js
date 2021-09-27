var arrPayStub;
$.getJSON("https://www.swollenhippo.com/getPayStubsByAPIKey.php?APIKey=DuffManSays,Phrasing!", function(result){
    arrPayStub = result;
    $.each(result,function(i,person){
        $('#divPayStubs tbody').append(buildEmployeeTableRow(person));
    })
}) 

var arrEmployees;
$.getJSON("https://www.swollenhippo.com/getProfileDetailsByAPIKey?APIKey=DuffManSays,Phrasing!", function(result){
    arrEmployees = result;
    $.each(result,function(i,person){
        $('#divEmployeeContainer').append(buildEmployeeCard(person));
    })
})

$(document).on('click','btnToggle',function(){
    $('#divToggleDetails').slideToggle();

})

function buildEmployeeTableRow(Pay){
    return '<tr><th>' + Pay.Month + '</th><th>' + Pay.Year + '</th><th>' + Pay.Sales + '</th><th>' + Pay.HoursWorked + '</th><th>' + Pay.HourlyRate + '</th><th>' + Pay.CommissionRate + '</th><th>' + Pay.TotalPay + '</th></tr>';
}

function buildEmployeeCard(Employee){
    strCardHTML =  '<div class="card col-4 row" style="display: inline-block;"></div>';
    strCardHTML += '<img src="images/archer.jpg" alt="Archer in office">';
    strCardHTML += '<h2 class="text-center mb-0"><a href="Name">' + Employee.FirstName + '' + Employeeloyee.LastName + '</a></h2>';
    strCardHTML += '<p class="text-center mt-0">' + Employee.CodeName + '</p>';
    strCardHTML += '<p class="text-center mt-0">' + Employee.BillingAgency + '</p>';
    strCardHTML += '<p class="text-center mt-0">' + Employee.FieldAgent + '</p>';
    strCardHTML += '<p class="text-center mt-0">' + Employee.HireDate + '</p>';
    strCardHTML += '<div>';
    strCardHTML += '<button type="button" class="btn btn-primary btn-block mb-3">Toggle Contact Details</button>';
    strCardHTML += '</div>';
    strCardHTML += '<p class="offset-2">Email: <a href="mailto:' + Employee.Email + '" class="aEmail">' + Employee.Email + '</a></p>';
    strCardHTML += '<p class="offset-2"">Phone Number: <a href="tel:' + Employee.Phone + '" class="aPhone">' + Employee.Phone + '</a></p>';
    strCardHTML += '<P class="offset-2">' + Employee.StreetAddress + '</p>';
    strCardHTML += '<p class="offset-2">' + Employee.City + '</P>';
    strCardHTML += '<P class="offset-2">' + Employee.State + '</p>';
    strCardHTML += '<P class="offset-2">' + Employee.ZipCode + '</p>';
    strCardHTML += '<P class="offset-2">' + Employee.EmergencyConact + '</p>';
    strCardHTML += '<p class="offset-2"">Phone Number: <a href="tel:' + Employee.Phone + '" class="aPhone">' + Employee.Phone + '</a></p>';
    strCardHTML += '</div>';
    strCardHTML += '</div>';
    return strCardHTML;
}