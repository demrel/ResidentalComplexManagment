$(document).ready(function () {
    $(document).on('mousedown', '.b', function () {
        $(this).parent().parent().remove();
    });

    $(document).on('click', '.addPaket', function () {
       
        if ($(this).text('sil')) {
            $(this).addClass('b');
        $('.selectpicker').selectpicker('render');

            $(".prependTemp").append(`
            <div class="d-md-flex align-items-center justify-content-start mb-5 paketBox">
          
          <div class="form-group mr-3">
            <label for="formGroupExampleInput">Xidməti növünü seçin</label>
            <select class=" form-control my-select border border-radius-card d-inline-block" >
                <option>Mustard</option>
                <option>Ketchup</option>
                <option>Barbecue</option>
            </select>
          </div>
          
          <div class="form-group mr-3">
            <label for="formGroupExampleInput">Xidməti seçin</label>
            <select class="form-control my-select border border-radius-card  d-inline-block" >
                <option>Mustard</option>
                <option>Ketchup</option>
                <option>Barbecue</option>
            </select>
          </div>
          
          
          <div class="form-group mr-3">
            <label for="formGroupExampleInput">Paketdə sayı</label>
            <input type="number" class="form-control" min='0' />
          </div>
          
          
          <div class="form-group  mr-3  ">
            <label for="formGroupExampleInput"></label>
            <button type="button" class="form-control btn btn-primary addPaket  " >Paketə əlavə et</button>
          </div>
          </div>
          `)
        }
    });

    $(".prependTemp").append(`
    <div class="d-md-flex align-items-center justify-content-start mb-5 paketBox">
          
    <div class="form-group mr-3">
      <label for="formGroupExampleInput">Xidməti növünü seçin</label>
      <select class=" form-control my-select border border-radius-card d-inline-block" >
          <option>Mustard</option>
          <option>Ketchup</option>
          <option>Barbecue</option>
      </select>
    </div>
    
    <div class="form-group mr-3">
      <label for="formGroupExampleInput">Xidməti seçin</label>
      <select class="form-control my-select border border-radius-card  d-inline-block" >
          <option>Mustard</option>
          <option>Ketchup</option>
          <option>Barbecue</option>
      </select>
    </div>
    
    
    <div class="form-group mr-3">
      <label for="formGroupExampleInput">Paketdə sayı</label>
      <input type="number" class="form-control" min='0' />
    </div>
    
    
    <div class="form-group mr-3">
      <label for="formGroupExampleInput"></label>
      <button type="button" class="form-control btn   btn-primary addPaket" >Paketə əlavə et</button>
    </div>
    </div>
`)
})