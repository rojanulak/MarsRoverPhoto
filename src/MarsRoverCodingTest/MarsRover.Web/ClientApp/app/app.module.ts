import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { RoverService } from './rover.service';   // our custom service, see below
import {IRoverImage} from './iroverimage';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule, NgbModule, FormsModule, HttpClientModule, 
        ],
    providers: [RoverService],
    bootstrap: [AppComponent]
})
export class AppModule { }
