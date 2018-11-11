var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var RoverService = /** @class */ (function () {
    function RoverService(http) {
        this.http = http;
        this.apiUrl = 'http://localhost:59582/api/getimagebyrover/';
    }
    RoverService.prototype.getRoverImages = function (roverName, earthDate) {
        return this.http.get(this.apiUrl + roverName + '/' + earthDate);
    };
    RoverService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], RoverService);
    return RoverService;
}());
export { RoverService };
//# sourceMappingURL=rover.service.js.map