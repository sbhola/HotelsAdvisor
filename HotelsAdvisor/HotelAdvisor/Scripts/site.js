jQuery(document).ready(function () {
    $(function () {
        $('.autocomplete-with-hidden').autocomplete({
            minLength: 0,
            source: function (request, response) {
                var url = $(this.element).data('url');

                $.getJSON(url, { term: request.term }, function (data) {
                    response(data);
                })
            },
            select: function (event, ui) {
                $("#search").prop("disabled", false);
                $("#SearchResult_SearchResultLine1[type=submit]").removeAttr("disabled");
                $(event.target).next('input[type=hidden]').val(ui.item.id);
                $("#SearchResult_Id").val(ui.item.Id);
                $("#SearchResult_Category").val(ui.item.Category);
                $("#SearchResult_SearchResultLine1").val(ui.item.SearchResultLine1);
                $("#SearchResult_SearchResultLine2").val(ui.item.SearchResultLine2);
                $("#SearchResult_SearchResultLine3").val(ui.item.SearchResultLine3);
            },
            change: function (event, ui) {
                if (!ui.item) {
                    $("#search").prop("disabled", true);
                    $("#SearchResult_SearchResultLine1[type=submit]").attr("disabled", "disabled")
                    $(event.target).val('').next('input[type=hidden]').val('');
                }
            }
        })
        .data("ui-autocomplete")._renderItem = function (ul, item) {

            if (item.Category == "Location") {
                $("#search").prop("disabled", true);
                $("#SearchResult_SearchResultLine1[type=submit]").attr("disabled", "disabled")
                return $("<li></li>")
               .data("item.autocomplete", item)
               .append("<a style=\"font-family: 'Lato', sans-serif\"><img src=\"https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQeYwroUJafjyDh2mqEudYWg-Ru6O81phd9GK_0bmH_kvzSudVW\" style=\"width:40px;height:40px\"/>&nbsp;&nbsp;&nbsp;&nbsp;" + item.SearchResultLine1 + "," + item.SearchResultLine2 + "," + item.SearchResultLine3 + "</a>")
               .appendTo(ul);
            }
            else if (item.Category == "Hotel") {
                $("#search").prop("disabled", true);
                $("#SearchResult_SearchResultLine1[type=submit]").attr("disabled", "disabled")
                return $("<li></li>")
               .data("item.autocomplete", item)
               .append("<a style=\"font-family: 'Lato', sans-serif\"><img src=\"http://png-3.findicons.com/files/icons/2016/vista_style_objects/256/hotel.png\" style=\"width:40px;height:40px\"/>&nbsp;&nbsp;&nbsp;&nbsp;" + item.SearchResultLine1 + "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + item.SearchResultLine2 + "," + item.SearchResultLine3 + "</a>")
               .appendTo(ul);
            }
            else {
                $("#search").prop("disabled", true);
                $("#SearchResult_SearchResultLine1[type=submit]").attr("disabled", "disabled")
                return $("<li class=\"ui-state-disabled\"></li>")
               .data("item.autocomplete", item)
               .append("<a style=\"font-family: 'Lato', sans-serif\">" + item.label + "</a>")
               .appendTo(ul);

            }

        };
    })
})