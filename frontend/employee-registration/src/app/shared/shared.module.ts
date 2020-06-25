import { CollapseModule } from 'ngx-bootstrap/collapse';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MainPrincipalComponent } from './main-principal/main-principal.component';
import { FooterComponent } from './footer/footer.component';
import { TopMenuComponent } from './top-menu/top-menu.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    CollapseModule
  ],
  declarations: [
    FooterComponent,
    TopMenuComponent,
    MainPrincipalComponent,
  ],
  exports: [
    FooterComponent,
    TopMenuComponent,
    MainPrincipalComponent,
  ]
})

export class SharedModule{}
