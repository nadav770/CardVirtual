
function openMailClient() {
    var email = "sa0533137520@gmail.com"; // כתובת המייל הקבועה
    var subject = "הרשמה";
    var body = "אני מעוניין להירשם";

    var gmailUrl = "https://mail.google.com/mail/?view=cm&fs=1&to=" +
        encodeURIComponent(email) +
        "&su=" + encodeURIComponent(subject) +
        "&body=" + encodeURIComponent(body);

    window.open(gmailUrl, "_blank");

    /*לפתיחה דרך אאוטלוק
   /* window.location.href = "mailto:" + email + "?subject=" + encodeURIComponent(subject) + "&body=" + encodeURIComponent(body);*/
}      
/*</script>*/