export interface Cars{
    id: number;
    brand: string;
    model: string;
    year: number;
    color: string;
    customerId: number;
    customer:{
        id: number;
        customer_name: string;
        customer_email: string;
        customer_phone: string;
    };
}