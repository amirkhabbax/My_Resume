$(document).ready(function () {
    $('.footer').css('margin-top', $(document).height() - ($('.container').height() + $('.footer').height()) - 50);

 
    $.getJSON("/api/persons", function (data) {
        $.each(data, function (i, field) {
            $("#bar").append(
                '<a href="/Persons" class="w3-button w3-circle w3-padding-small w3-metro-green w3-hover-green w3-ripple" style = "margin-left:17px;" > ' +
                '<i class="fas fa-user-cog w3-small"></i> ' +
                '</a>' +
                '<a href="' +
                field.facebook +
                '" class="w3-button w3-circle w3-padding-small w3-blue w3-ripple" style = "margin-right:10px; float:right;" > ' +
                '<i class="fab fa-facebook "></i> ' +
                '</a>' +
                '<a href="' +
                field.github +
                '" class="w3-button w3-circle w3-padding-small w3-blue w3-ripple" style="margin-right:5px; float:right;" >' +
                '<i class="fab fa-github "></i> ' +
                '</a>' +
                '<a href="' +
                field.linkedIn +
                '" class="w3-button w3-circle w3-padding-small w3-blue w3-ripple" style = "margin-right:5px; float:right;" > ' +
                '<i class="	fab fa-linkedin"></i> ' +
                '</a>' +
                '<a href="' +
                field.twitter +
                '" class="w3-button w3-circle w3-padding-small w3-blue w3-ripple" style = "margin-right:5px; float:right;" > ' +
                '<i class="fab fa-twitter "></i> ' +
                '</a>');

            $("#mySidebar h4").append(field.name);
            $("#mySidebar h6").append('Backend Developer, Frontend Developer, ' +
                'Game Developer<br>');
            $("#myTable table").append(
                '<tr>' +
                '<td>' +
                '<i class="fas fa-phone w3-large"></i> ' +
                '</td>' +
                '<td>' +
                field.countryPhonePrefix + ' ' + field.phoneNumber +
                '</td>' +
                '</tr>' +
                '<tr>' +
                '<td style="font-size:14px;">' +
                '<i class="fas fa-envelope w3-large"></i> ' +
                '</td>' +
                '<td>' +
                field.email +
                '</td>' +
                '</tr>');

            $("#name h2 ").append(field.name);
            $("#name_ p ").append("- " + field.name + "'s Portfolio");
        });

    });
});

function w3_open() {
    document.getElementById("main").style.marginLeft = "25%";
    document.getElementById("mySidebar").style.width = "25%";
    document.getElementById("mySidebar").style.display = "block";
    document.getElementById("openNav").style.display = 'none';
}
function w3_close() {
    document.getElementById("main").style.marginLeft = "0%";
    document.getElementById("mySidebar").style.display = "none";
    document.getElementById("openNav").style.display = "inline-block";
}
