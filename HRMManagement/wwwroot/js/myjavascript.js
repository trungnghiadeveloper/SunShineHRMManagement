var ETogglePassword = document.querySelector("#toggle-password");
var EPassword = document.querySelector("#password");
var ELogout = document.querySelector("#logout");

ETogglePassword?.addEventListener("click", function () {
    if (EPassword.type == "text") {
        EPassword.type = "password"; 
    } else {
        EPassword.type = "text";
    }
});

ELogout.addEventListener("click", function () {
    console.log("click");
    document.cookie = "UserId=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    document.cookie = "UserName=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    window.location.href = "/OAuth/Login";
});