    function redirectToHomePage() {
        var selectedRole = $("#roles").val(); 
        if (selectedRole === "Admin") {
            window.location.href = "/Admin/Index";
        } else if (selectedRole === "Client") {
            window.location.href = "/";
        }
    }