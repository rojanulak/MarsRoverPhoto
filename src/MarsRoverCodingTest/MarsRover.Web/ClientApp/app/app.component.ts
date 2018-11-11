import { Component } from '@angular/core';
import { IRoverImage } from './iroverimage'
import { RoverService } from './rover.service';
@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    model: any = {};
    images: IRoverImage[] = [];
    public loading = false;

    constructor(
        private roverService: RoverService) { }

    title = 'Welcome to Mars Rover Image Archive';
    subtitle = 'Images capctured by Nasa Mars Rovers';
    search() {
        this.loading = true;

        var formattedDate = this.model.earthDate.year + '-' + this.model.earthDate.month + '-' + this.model.earthDate.day;
        this.roverService.getRoverImages(this.model.roverName, formattedDate).subscribe(images => {
            this.loading = false;

            this.images = images;
        });
    }
}
