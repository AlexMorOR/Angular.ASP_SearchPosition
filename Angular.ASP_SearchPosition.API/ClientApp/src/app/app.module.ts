import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SearchPageComponent } from './search-page/search-page.component';
import { SearchFormComponent } from './search-page/search-form/search-form.component';
import { SearchHistoryPageComponent } from './search-history-page/search-history-page.component';
import { SearchCardComponent } from './search-history-page/search-card/search-card.component';
import { LogCardComponent } from './search-history-page/log-card/log-card.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SearchPageComponent,
    SearchFormComponent,
    SearchHistoryPageComponent,
    SearchCardComponent,
    LogCardComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'search', component: SearchPageComponent },
      { path: 'history', component: SearchHistoryPageComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
