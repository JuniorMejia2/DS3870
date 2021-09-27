var arrProfileData;
$.getJSON("https://www.swollenhippo.com/getProfileDetailsByAPIKey.php?APIKey=DuffManSays,Phrasing!&Codename=Duchess",function(result){
    console.log(result);
    arrProfileData = result;
    fillProfile(arrProfileData [0]);
})

function fillProfile(Employee){
    $('#txtEmployeeName').text(Employee.FirstName + '' + Employee.LastName)
    $('#txtCodeName').text(Employee.CodeName)
    $('#txtPosition').text(Employee.Position)


}