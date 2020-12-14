// import { ProfileUser } from './../../modules/auth/models/profile-user';
// import { ProfileComponent } from './../../modules/auth/page/profile/profile.component';
// import { Component, OnInit, Input, ElementRef } from '@angular/core';
// import { MatSidenav } from '@angular/material/sidenav';
// import { AuthService } from 'src/app/modules/auth/auth.service';
// import { Router } from '@angular/router';
// import { MatDialog } from '@angular/material/dialog';
// import { environment } from 'src/environments/environment';
// import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
// import { ROUTES } from '../sidebar/sidebar.component';
// @Component({
//   selector: 'app-nav',
//   templateUrl: './nav.component.html',
//   styleUrls: ['./nav.component.scss']
// })
// export class NavComponent implements OnInit {
//   avatarURL: string;
//   // tslint:disable-next-line: no-input-rename
//   @Input('snav') snav: MatSidenav;
//   profileUser = new ProfileUser();
//   isSearchOpen = false;
//   showAvatar = false;
//   showReload = false;
//   showAvatarFake = false;
//   private listTitles: any[];
//   location: Location;
//   mobile_menu_visible: any = 0;
//   private toggleButton: any;
//   private sidebarVisible: boolean;
//   constructor(
//     private authService: AuthService,
//     private router: Router,
//     public dialog: MatDialog,
//     location: Location,
//     private element: ElementRef,
//   ) {
//     this.location = location;
//     this.sidebarVisible = false;
//   }

//   ngOnInit() {
//     if (this.authService.getAvatarUrl()) {
//       this.avatarURL = this.authService.getAvatarUrl();
//     } else {
//       this.avatarURL = environment.defaultAvatarURL;
//     }
//     this.listTitles = ROUTES.filter(listTitle => listTitle);
//     const navbar: HTMLElement = this.element.nativeElement;
//     this.toggleButton = navbar.getElementsByClassName('navbar-toggler')[0];
//     this.router.events.subscribe((event) => {
//       this.sidebarClose();
//       const $layer: any = document.getElementsByClassName('close-layer')[0];
//       if ($layer) {
//         $layer.remove();
//         this.mobile_menu_visible = 0;
//       }
//     });
//   }

//   openProfile() {
//     const viewDialog = this.dialog.open(ProfileComponent, {
//       width: '50%',
//       disableClose: true,
//     });
//   }

//   openSearch() {
//     this.isSearchOpen = !this.isSearchOpen;
//   }

//   logout() {
//     this.authService.logout();
//   }

//   changePassword() {
//     this.router.navigate(['auth/changepassword']);
//   }

//   getTitle() {
//     let titlee = this.location.prepareExternalUrl(this.location.path());
//     if (titlee.charAt(0) === '#') {
//       titlee = titlee.slice(1);
//     }

//     for (let item = 0; item < this.listTitles.length; item++) {
//       if (this.listTitles[item].path === titlee) {
//         return this.listTitles[item].title;
//       }
//     }
//     return 'Dashboard';
//   }

//   sidebarOpen() {
//     const toggleButton = this.toggleButton;
//     const body = document.getElementsByTagName('body')[0];
//     setTimeout(function () {
//       toggleButton.classList.add('toggled');
//     }, 500);

//     body.classList.add('nav-open');

//     this.sidebarVisible = true;
//   }
//   sidebarClose() {
//     const body = document.getElementsByTagName('body')[0];
//     this.toggleButton.classList.remove('toggled');
//     this.sidebarVisible = false;
//     body.classList.remove('nav-open');
//   }

//   close() {
//     this.location.back();
//   }
//   sidebarToggle() {
//     // const toggleButton = this.toggleButton;
//     // const body = document.getElementsByTagName('body')[0];
//     const $toggle = document.getElementsByClassName('navbar-toggler')[0];

//     if (this.sidebarVisible === false) {
//       this.sidebarOpen();
//     } else {
//       this.sidebarClose();
//     }
//     const body = document.getElementsByTagName('body')[0];

//     if (this.mobile_menu_visible == 1) {
//       // $('html').removeClass('nav-open');
//       body.classList.remove('nav-open');
//       // if ($layer) {
//       //     $layer.remove();
//       // }
//       setTimeout(function () {
//         $toggle.classList.remove('toggled');
//       }, 400);

//       this.mobile_menu_visible = 0;
//     } else {
//       setTimeout(function () {
//         $toggle.classList.add('toggled');
//       }, 430);

//       const $layer = document.createElement('div');
//       $layer.setAttribute('class', 'close-layer');


//       if (body.querySelectorAll('.main-panel')) {
//         document.getElementsByClassName('main-panel')[0].appendChild($layer);
//       } else if (body.classList.contains('off-canvas-sidebar')) {
//         document.getElementsByClassName('wrapper-full-page')[0].appendChild($layer);
//       }

//       setTimeout(function () {
//         $layer.classList.add('visible');
//       }, 100);

//       $layer.onclick = function () { // asign a function
//         body.classList.remove('nav-open');
//         this.mobile_menu_visible = 0;
//         $layer.classList.remove('visible');
//         setTimeout(function () {
//           $layer.remove();
//           $toggle.classList.remove('toggled');
//         }, 400);
//       }.bind(this);

//       body.classList.add('nav-open');
//       this.mobile_menu_visible = 1;

//     }
//   }
// }
import { Component, OnInit, Input, Renderer2, ViewChild, ElementRef, Directive } from '@angular/core';
import { ROUTES } from '../sidebar/sidebar.component';
import { Router, ActivatedRoute, NavigationEnd, NavigationStart } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { AuthService } from 'src/app/modules/auth/auth.service';
import { ProfileUser } from './../../modules/auth/models/profile-user';
import { ProfileComponent } from './../../modules/auth/page/profile/profile.component';
import { MatSidenav } from '@angular/material/sidenav';
import { MatDialog } from '@angular/material/dialog';
import { environment } from 'src/environments/environment';
const misc: any = {
  navbar_menu_visible: 0,
  active_collapse: true,
  disabled_collapse_init: 0,
};

declare var $: any;
@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
//   avatarURL: string;
//   // tslint:disable-next-line: no-input-rename
//   @Input('snav') snav: MatSidenav;
//   profileUser = new ProfileUser();
//   isSearchOpen = false;
//   showAvatar = false;
//   showReload = false;
//   showAvatarFake = false;
//   private listTitles: any[];
//   location: Location;
//   mobile_menu_visible: any = 0;
//   private toggleButton: any;
//   private sidebarVisible: boolean;
//   constructor(
//     private authService: AuthService,
//     private router: Router,
//     public dialog: MatDialog,
//     location: Location,
//     private element: ElementRef,
//   ) {
//     this.location = location;
//     this.sidebarVisible = false;
//   }
export class NavComponent implements OnInit {
  private listTitles: any[];
  location: Location;
  mobile_menu_visible: any = 0;
  private nativeElement: Node;
  private toggleButton: any;
  private sidebarVisible: boolean;
  private _router: Subscription;
  @ViewChild('app-navbar-cmp', { static: false }) button: any;

  constructor(
    location: Location,
    private renderer: Renderer2,
    private element: ElementRef,
    private router: Router,
    private authService: AuthService

    ) {
    this.location = location;
    this.nativeElement = element.nativeElement;
    this.sidebarVisible = false;

  }
  minimizeSidebar() {
    const body = document.getElementsByTagName('body')[0];

    if (misc.sidebar_mini_active === true) {
      body.classList.remove('sidebar-mini');
      misc.sidebar_mini_active = false;

    } else {
      setTimeout(function () {
        body.classList.add('sidebar-mini');

        misc.sidebar_mini_active = true;
      }, 300);
    }

    // we simulate the window Resize so the charts will get updated in realtime.
    const simulateWindowResize = setInterval(function () {
      window.dispatchEvent(new Event('resize'));
    }, 180);

    // we stop the simulation of Window Resize after the animations are completed
    setTimeout(function () {
      clearInterval(simulateWindowResize);
    }, 1000);
  }

  hideSidebar() {
    const body = document.getElementsByTagName('body')[0];
    const sidebar = document.getElementsByClassName('sidebar')[0];

    if (misc.hide_sidebar_active === true) {
      setTimeout(function () {
        body.classList.remove('hide-sidebar');
        misc.hide_sidebar_active = false;
      }, 300);
      setTimeout(function () {
        sidebar.classList.remove('animation');
      }, 600);
      sidebar.classList.add('animation');

    } else {
      setTimeout(function () {
        body.classList.add('hide-sidebar');
        // $('.sidebar').addClass('animation');
        misc.hide_sidebar_active = true;
      }, 300);
    }

    // we simulate the window Resize so the charts will get updated in realtime.
    const simulateWindowResize = setInterval(function () {
      window.dispatchEvent(new Event('resize'));
    }, 180);

    // we stop the simulation of Window Resize after the animations are completed
    setTimeout(function () {
      clearInterval(simulateWindowResize);
    }, 1000);
  }

  ngOnInit() {
    this.listTitles = ROUTES.filter(listTitle => listTitle);

    const navbar: HTMLElement = this.element.nativeElement;
    const body = document.getElementsByTagName('body')[0];
    this.toggleButton = navbar.getElementsByClassName('navbar-toggler')[0];
    if (body.classList.contains('sidebar-mini')) {
      misc.sidebar_mini_active = true;
    }
    if (body.classList.contains('hide-sidebar')) {
      misc.hide_sidebar_active = true;
    }
    // this._router = this.router.events.filter(event => event instanceof NavigationEnd).subscribe((event: NavigationEnd) => {
    //   this.sidebarClose();

    //   const $layer = document.getElementsByClassName('close-layer')[0];
    //   if ($layer) {
    //     $layer.remove();
    //   }
    // });
  }
  onResize(event) {
    if ($(window).width() > 991) {
      return false;
    }
    return true;
  }
  sidebarOpen() {
    var $toggle = document.getElementsByClassName('navbar-toggler')[0];
    const toggleButton = this.toggleButton;
    const body = document.getElementsByTagName('body')[0];
    setTimeout(function () {
      toggleButton.classList.add('toggled');
    }, 500);
    body.classList.add('nav-open');
    setTimeout(function () {
      $toggle.classList.add('toggled');
    }, 430);

    var $layer = document.createElement('div');
    $layer.setAttribute('class', 'close-layer');


    if (body.querySelectorAll('.main-panel')) {
      document.getElementsByClassName('main-panel')[0].appendChild($layer);
    } else if (body.classList.contains('off-canvas-sidebar')) {
      document.getElementsByClassName('wrapper-full-page')[0].appendChild($layer);
    }

    setTimeout(function () {
      $layer.classList.add('visible');
    }, 100);

    $layer.onclick = function () { //asign a function
      body.classList.remove('nav-open');
      this.mobile_menu_visible = 0;
      this.sidebarVisible = false;

      $layer.classList.remove('visible');
      setTimeout(function () {
        $layer.remove();
        $toggle.classList.remove('toggled');
      }, 400);
    }.bind(this);

    body.classList.add('nav-open');
    this.mobile_menu_visible = 1;
    this.sidebarVisible = true;
  };
  sidebarClose() {
    var $toggle = document.getElementsByClassName('navbar-toggler')[0];
    const body = document.getElementsByTagName('body')[0];
    this.toggleButton.classList.remove('toggled');
    var $layer = document.createElement('div');
    $layer.setAttribute('class', 'close-layer');

    this.sidebarVisible = false;
    body.classList.remove('nav-open');
    // $('html').removeClass('nav-open');
    body.classList.remove('nav-open');
    if ($layer) {
      $layer.remove();
    }

    setTimeout(function () {
      $toggle.classList.remove('toggled');
    }, 400);

    this.mobile_menu_visible = 0;
  };
  sidebarToggle() {
    if (this.sidebarVisible === false) {
      this.sidebarOpen();
    } else {
      this.sidebarClose();
    }
  }

  logout() {
    this.authService.logout();
  }

  changePassword() {
    this.router.navigate(['auth/changepassword']);
  }
  getTitle() {
    var titlee = this.location.prepareExternalUrl(this.location.path());
    if (titlee.charAt(0) === '#') {
      titlee = titlee.slice(1);
    }
    for (let i = 0; i < this.listTitles.length; i++) {
      if (this.listTitles[i].type === "link" && this.listTitles[i].path === titlee) {
        return this.listTitles[i].title;
      } else if (this.listTitles[i].type === "sub") {
        for (let j = 0; j < this.listTitles[i].children.length; j++) {
          let subtitle = this.listTitles[i].path + '/' + this.listTitles[i].children[j].path;
          // console.log(subtitle)
          // console.log(titlee)
          if (subtitle === titlee) {
            return this.listTitles[i].children[j].title;
          }
        }
      }
    }
    return 'Dashboard';
  }
  getPath() {
    return this.location.prepareExternalUrl(this.location.path());
  }
}
