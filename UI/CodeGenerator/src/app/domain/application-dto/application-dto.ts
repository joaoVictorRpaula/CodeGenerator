import { DbInformation } from "../db-information/db-information";

export class ApplicationDto {
    ApplicationName : string = "";
    Path : string = "";
    TemplateName : string = "";
    DbInformation : DbInformation = new DbInformation();
}
