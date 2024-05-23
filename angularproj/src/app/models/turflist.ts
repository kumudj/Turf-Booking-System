export class Turf {
    id: number;
    name: string;
    location: string;
    availability: boolean;
    // bookings: Booking[]; // Assuming you have a Booking class
  
    constructor(data: any = {}) {
      this.id = data.id || 0;
      this.name = data.name || '';
      this.location = data.location || '';
      this.availability = data.availability || false;
    //   this.bookings = data.bookings || [];
    }
  }