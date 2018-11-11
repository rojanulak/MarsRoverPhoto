import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IRoverImage } from './iroverimage';

@Injectable()
export class RoverService {
    constructor(private http: HttpClient) { }

    apiUrl = 'http://localhost:59582/api/getimagebyrover/';

    getRoverImages(roverName: string, earthDate: string) {
        return this.http.get<IRoverImage[]>(this.apiUrl + roverName + '/' + earthDate);
    }
}