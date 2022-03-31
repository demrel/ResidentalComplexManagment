class MyHeader extends HTMLElement {
  connectedCallback() {
    this.innerHTML = ` 

      <header class="navTop px-4 py-2 shadowBox">

<div class="navTopFlex d-flex   align-items-center justify-content-between">

    <div class="navTopLeft">
        <h3>Logo</h3>
    </div>

    <div class="navTopRight ">
    
        <div class="navTopRightElement d-flex align-items-center ">

            <div class="notification d-flex align-items-center ml-2 mr-4">
                <i class="far fa-bell notificationIcon fa-lg colorSecondary "></i>
                <div class="notificationNumber">2</div>
            </div>

            <div class='mr-1'> 
              Ronnie Woodkin
            </div> 

         
            <button class="navbar-toggler pl-3 p-0  d-md-none collapsed" type="button" data-toggle="collapse" data-target="#sidebarMenu" aria-controls="sidebarMenu" aria-expanded="false" aria-label="Toggle navigation">
              <i class="fas fa-bars"></i>
            </button>

        </div>
        
    </div>
</div>
</header>



     `;
  }
}

customElements.define('my-header', MyHeader);


class MySidebar extends HTMLElement {
  connectedCallback() {
    this.innerHTML = `
    
      <nav id="sidebarMenu" class="col-md-3 col-lg-2 d-md-block bg-light sidebar collapse">
    <div class="sidebar-sticky pt-3 ">
      <ul class="nav flex-column">
        <li class="nav-item w-100">
          <a class="nav-link active" href="../index.html">
          <i class="fas fa-home colorSecondary  fa-lg  mr-3"></i> Ana səhifə
          </a>
        </li>
        <li class="nav-item w-100">
          <a class="nav-link" href="../Area/area.html">
          <i class="far fa-chart-bar colorSecondary fa-lg  mr-3" ></i>  Ərazi

          </a>
        </li>
        <li class="nav-item w-100">
          <a class="nav-link" href="../Anbar/anbar.html">
          <i class="far fa-envelope colorSecondary fa-lg mr-3"></i> Anbar
          </a>
        </li>
        <li class="nav-item w-100">
          <a class="nav-link" href="../Contracts/contracts.html">
          <i class="far fa-file-alt colorSecondary  fa-lg  mr-3"></i> Müqavilələr
          </a>
        </li>
        <li class="nav-item w-100">
          <a class="nav-link" href="../Contractors/contractors.html">
          <i class="fas fa-user-friends colorSecondary fa-lg  mr-3"></i>  Kontragentlər
          </a>
        </li>
        <li class="nav-item w-100">
          <a class="nav-link" href="../Payments/payments.html">
          <i class="far fa-comment-dots mr-3 fa-lg colorSecondary"></i>  Ödənişlər
          </a>
        </li>

        <li class="nav-item w-100">
            <a class="nav-link" href="../debts.html"">
            <i class="far fa-calendar-minus colorSecondary mr-3 fa-lg "></i> Borclar
            </a>
          </li>

          <li class="nav-item w-100">
            <a class="nav-link" href="#">
            <i class="far fa-question-circle colorSecondary mr-3 fa-lg"></i> Help Center
            </a>
          </li>

          <li class="nav-item w-100">
            <a class="nav-link" href="../Users/users.html">
            <i class="fas fa-cog colorSecondary mr-3 fa-lg"></i>  Settings
            </a>
          </li>
      </ul>

   
    </div>
  </nav>
     `;
  }
}

customElements.define('my-sidebar', MySidebar);


class MyPagination extends HTMLElement {
  connectedCallback() {
    this.innerHTML = `
    <nav class="mt-4">
    <ul class="pagination ">
        <li class="page-item ">
            <a class="page-link border-0" href="#" aria-label="Previous">
            <i class="fas fa-chevron-left"></i>
            </a>
        </li>
        <li class="page-item active "><a class="page-link border-radius-card " href="#">1</a></li>
        <li class="page-item"><a class="page-link border-0" href="#">2</a></li>
        <li class="page-item"><a class="page-link border-0" href="#">3</a></li>
        <li class="page-item">
            <a class="page-link border-0" href="#" aria-label="Next">
            <i class="fas fa-chevron-right"></i>
            </a>
        </li>
    </ul>
</nav>
     `;
  }
}

customElements.define('my-pagination', MyPagination);



class MyLink extends HTMLElement {
  connectedCallback() {
    this.innerHTML = `
    <link rel="stylesheet" href="../vendors/fontawesome/css/all.css">
    <link rel="stylesheet" href="../vendors/bootstrap/css/bootstrap.min.css">

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css">

    <link rel="stylesheet" href="../assets/css/style.css">

    <link rel="stylesheet" type="text/css" href="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css" />

    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@200;400;500;700&display=swap" rel="stylesheet">
     `;
  }
}

customElements.define('my-link', MyLink);


class UserTitle extends HTMLElement{
constructor(){
  super();
  this.innerHTML = `
  
  <h2 class="h2">${this.getAttribute('title')}</h2>


  `
}
}

customElements.define('user-title', UserTitle);


class UserLink extends HTMLElement{
  constructor(){
    super();
    this.innerHTML = `
    <div class="btn-toolbar mb-2 mb-md-0">
        <div class="btn-group w-100 ">
            <a href="${this.getAttribute('link')}" type="button" class="btn p-2   text-white border bg-primary">${this.getAttribute('linkName')}
            </a>
        </div>
    </div>
    `
  }
  }
  
  customElements.define('user-link', UserLink);



