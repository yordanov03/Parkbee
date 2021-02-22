import { Door } from "./door.model";

export class Garage{
    public garageId: number;
    public name: string;
    public status: number;
    public doors: Door[];


constructor(garageId: number, 
    name: string, 
    status: number, 
    doors: Door[]){
    this.garageId = garageId;
    this.name = name;
    this.status = status;
    this.doors = doors;
}

}