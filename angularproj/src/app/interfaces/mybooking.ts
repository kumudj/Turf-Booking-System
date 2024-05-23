export interface IBooking{
    id?: number,
    date: Date,
    startTime: string,
    endTime: string,
    userId: number,
    turfId: number;
    turfName: string;

}