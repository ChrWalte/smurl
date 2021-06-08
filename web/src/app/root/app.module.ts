import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppRoutingModule } from './routing/app-routing.module';
import { InfoComponent } from './info/info.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { AppComponent } from './app/app.component';
import { LinkService } from '../shared/services/link-service/link.service';
import { ReRouteComponent } from './re-route/re-route.component';

@NgModule({
  declarations: [
    AppComponent,
    InfoComponent,
    HeaderComponent,
    FooterComponent,
    ReRouteComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    HttpClientModule,

    AppRoutingModule,

    FontAwesomeModule,
  ],
  providers: [LinkService],
  bootstrap: [AppComponent],
})
export class AppModule {}
