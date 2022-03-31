//data
$(function() {

    var start = moment().subtract(29, 'days');
    var end = moment();

    function cb(start, end) {
        $('#reportrange span').html(start.format('MMM/YYYY') + ' - ' + end.format('MMM/YYYY'));
    }

    $('#reportrange').daterangepicker({
        startDate: start,
        endDate: end,
        "opens": "left",
        "autoApply": true,

      
    }, cb);

    cb(start, end);

});

//selectpicker for table

(function($) {
    $.fn.tableFilterHeaders = function(filterFn) {
      this.each((index, header) => {
        let $header = $(header),
            $table = $header.closest('table'),
            text = $header.text(),
            colIndex = $header.closest('th').index(),
            fieldName = $header.attr('data-field-name') || text.toLowerCase(),
        $select = $('<select data-style="bg-transparent theadSize p-0 font-weight-bold border-0 text-dark" data-width="100%" class="selectpicker">')
          .data('fieldName', fieldName)
          .append($('<option>').text(text).val('').prop('disabled', true))
          .append($('<option>').text('All').val('all'))
          .append($table.find('tbody tr')
            .toArray()
            .map(tr => {
              return $(tr).find(`td:eq(${colIndex})`).text();
            })
            .filter(text => text.trim().length > 0)
            .sort()
            .filter((v, i, a) => a.indexOf(v) === i)
            .map(text => {
              return $('<option>').text(text).val(text);
            }));
        $header.empty().append($select.val('').on('change', filterFn));
      });
    };
    $.fn.initRowClasses = function(oddCls, evenCls) {
      this.find('tbody tr').each(function(i) {
        $(this).toggleClass(oddCls, i % 2 == 0).toggleClass(evenCls, i % 2 == 1);
      });
    };
  
  })(jQuery);
  
  $('.dropdown-header').tableFilterHeaders(filterText);
  
  function filterText(e) {
    let $filter = $(e.target),
        $table = $filter.closest('table'),
        $filters = $table.find('.dropdown-header select'),
    filterObj = $filters.toArray().reduce((obj, filter) => {
      let $filter = $(filter);
      return Object.assign(obj, { [$filter.data('fieldName')] : $filter.val() });
    }, {});
    if ($filter.val() === 'all') {
      $filter.val('')
    }
    $table.find('tbody tr').each(function() {
      $(this).toggle($(this).find('td').toArray().every(td => {
        let $td = $(td), fieldName = $td.attr('data-field-name');
        if (fieldName != null) {
          return filterObj[fieldName] === null ||
            filterObj[fieldName] === '' ||
            filterObj[fieldName] === 'all' ||
            filterObj[fieldName] === $td.text();
        }
        return true;
      }));
    });
  
  }





  $(".custom-file-input").on("change", function() {
    var fileName = $(this).val().split("\\").pop();
    $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
  });




  $(document).ready(function(){
    // Check or Uncheck All checkboxes
    $("#checkall").change(function(){
      var checked = $(this).is(':checked');
      if(checked){
        $(".checkbox").each(function(){
          $(this).prop("checked",true);
        });
      }else{
        $(".checkbox").each(function(){
          $(this).prop("checked",false);
        });
      }
    });
  
   // Changing state of CheckAll checkbox 
   $(".checkbox").click(function(){
  
     if($(".checkbox").length == $(".checkbox:checked").length) {
       $("#checkall").prop("checked", true);
     } else {
       $("#checkall").prop("checked", false);
     }
 
   });
 });
 