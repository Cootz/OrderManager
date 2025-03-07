export class Order
{
    id;
    departureCity;
    departureLocation;
    arrivalCity;
    arrivalLocation;
    weight;
    pickupDate;

    constructor() {
        this.id = undefined;
        this.departureCity = "";
        this.departureLocation = "";
        this.arrivalCity = "";
        this.arrivalLocation = "";
        this.weight = 0;
        this.pickupDate = "";
    }
}