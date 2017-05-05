$(document).ready(function(){
  $("#claim-form").submit(function(event) {
    event.preventDefault();
    var jobData = {};
    var dataArray = (($(this).serializeArray()));
    var urlAction = $(this).data('url-action');
    var errorbtn = $('.claimed-error');
    var successbtn = $('.claimed-tag');
    var claimbtn = $('.claim-button');
    for (let i = 0; i < dataArray.length; i++) {
        jobData[dataArray[i].name] = dataArray[i].value;
    }
    $.ajax({
      url: urlAction,
      type: 'POST',
      datatype: 'json',
      data: jobData,
      success: function(result) {
        claimbtn.addClass("hide");
        successbtn.removeClass("hide");
      },
      error: function(result) {
        claimbtn.addClass("hide");
        errorbtn.removeClass("hide");
      }
    })
  })
})
