var x;
$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "api/Report/index",
        dataType: "xml",
        success: xmlParser
    });


    function xmlParser(xml) {
        x = xml;
        $(".report-container").html("");
        $(xml).find("string").each(function () {
            $(".report-container").append($(this).text());
            $(".report-container").append('<br>');

        });
    }

    function xmlParser2(xml) {
        x = xml;
        $(".report-container").html("");
        $(xml).find("string").each(function () {
            $(".report-container").load($(this).text());
        });
    }



    $("a").click(function () {
        if ($(this).attr("href").indexOf("/api/Report/report") >= 0) {
            $.ajax({
                type: "GET",
                url: $(this).attr("href"),
                dataType: "xml",
                success: xmlParser2
            });
        }
        else {
            $.ajax({
                type: "GET",
                url: $(this).attr("href"),
                dataType: "xml",
                success: xmlParser
            });
        }
        return false;
    });


    
})