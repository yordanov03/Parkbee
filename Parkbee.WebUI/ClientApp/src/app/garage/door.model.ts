

export class Door{
   public doorId: number;
   public garageId: number;
   public status: number;
   public ipAddress: string;

   constructor(doorId: number, 
    garageId: number,
    status: number,
    ipAddress: string){
        this.doorId = doorId;
        this.garageId = garageId;
        this.status = status;
        this.ipAddress = ipAddress
    }


}