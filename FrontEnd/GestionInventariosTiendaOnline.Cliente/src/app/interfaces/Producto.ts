export interface Producto {
     id:number,
     name:string,
     description:string,
     price:number,
     category: string
     quantityInventory:number,
}

export interface ResponseProducto { productos: Producto[]; }