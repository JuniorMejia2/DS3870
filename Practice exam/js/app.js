var arrEmployees;
$.getJSON("https://www.swollenhippo.com/getStaffByAPIKey.php", function(result){
    console.log(result);
    arrEmployees = result;
    buildEmployeeCard();
    $.each(result,function(i,person){
        console.log(person.FirstName);
        console.log(person.FirstName + ' ' + person.LastName);
        console.log(person.Position);
        console.log(person.PhoneNumber);
        console.log(person.PayRate);
        console.log(person.Hoursworked);
        console.log(person.TaxRate);
        $('#txtEmail').val(person.Email);
    })
})

function buildEmployeeCard(){
    $.each(arrEmployees,function(i,person){
        if(person.FirstName != ''){
        strHTML = '<div class="container">';
        strHTML = '<div class="card col-4 offset-4 mt-5" id="card">';
        strHTML = '<h1 class="text-center mt-3">Employee</h1>';
        strHTML = '<img src="images/profile.png" alt="blue profile picture">';
        strHTML = '<form id="frmEmployee">';
        strHTML = '<h1 class="text-center mt-3">' + person.FirstName + '</h1>';
        strHTML = '<h2 class="text-center mt-1">' + person.Position + '</h2>';
        strHTML = '<h3>Contact details</h3>';
        strHTML = '<p class="offset-1">' + person.PhoneNumber + '</p>';
        strHTML = '<p class="offset-1">' + person.Email + '</p>';
        strHTML = '<h3>' + person.Address + '</h3>';
        strHTML = '<h3>Pay details</h3>';
        strHTML = '<p class="offset-1">' + person.PayRate + '</p>';
        strHTML = '<p class="offset-1">' + person.Hoursworked + '</p>';
        strHTML = '<p class="offset-1">' + person.TaxRate + '</p>';
        strHTML = '<div class="form-group">';
        strHTML = '<label for="txtGoalPay" class="form-label">Goal Pay</label>';
        strHTML = '<input type="GoalPay" class="form-control" id="txtGoalPay" placeholder="$0">';
        strHTML = '</div>';
        strHTML = '</form>';
        strHTML = '</div>';
        $('body').append(strHTML);
        } 
    });

    $('#btnTest').click(function() {
        const decTaxRate = .0925;
        let decHours = $('#txtHours').val();
        let decRate = $('#txtPayRate').val();
        console.log(decHours * decRate);
    })