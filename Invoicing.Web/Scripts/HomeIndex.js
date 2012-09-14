$(document).ready(function() {

    $('#partSearch').autocomplete({
        source: "/Home/GetPartsList",
        minLength: 0
    });


    $('#addRow').click(function () {
        var name = $('#partSearch').val();
        
        $.ajax({
            url: "/Home/GetLineItem/",
            data: { name: name},
            type: 'GET',
            dataType: 'html', 
            success: doSubmitSuccess
        });
    });
    
    function doSubmitSuccess(result) {
        $('#prodTable').append(result);
    }

    $('#calcpayments').click(function() {
        var parts = new Array();
        var rows = $('#prodTable tr:gt(0)');

        rows.each(function(index) {
            var name = $(this).find('td').eq(0).html();
            var qty = $(this).find('input').eq(1).val();
            var discount = $(this).find('input').eq(0).val();

            var part = {
                PartName: name,
                Quantity: qty,
                DiscountPercent: discount
            };
            parts.push(part);
        });

        var credit = $("#credit").val();
        var gift = $("#gift").val();
        var apr = $("#apr").val();
        var terms = $("#terms").val();
        
        var data = {
            CreditAmount: credit,
            GiftCardAmount: gift,
            APR: apr,
            Terms: terms,
            Parts: parts
        };

        $.ajax({
            url: '/Home/CalcPaymentSchedule',
            type: 'POST',
            dataType: 'json',
            data: JSON.stringify(data),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                UpdatePaymentSchedule(data);
            }
        });
    });
    
    function UpdatePaymentSchedule(data) {
        $('#payamt').html(data.AmountDue);
        $('#paymonth').html(data.Payment);
        $('#payfinal').html(data.Final);
        $('#paygift').html(data.Gift);
        $('#paycredit').html(data.Credit);
    }
});


