import { HttpClient } from "@angular/common/http";
import { ApplicationDto } from "./application-dto";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn:'root'
  })
export class ApplicationDtoEndpoint {
    
    get endpoint(): string {
        return "/CodeGenerator";
    }

    constructor(private httpClient : HttpClient) {}

    generate(applicationDto : ApplicationDto) : Observable<ApplicationDto>{
        var generateEndpoint = "/Generate";
        return this.httpClient.post<ApplicationDto>(environment.apiUrl + this.endpoint + generateEndpoint, applicationDto)
      }
    
}
