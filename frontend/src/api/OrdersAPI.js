const BaseAdrress = "http://localhost:12315";

export async function postOrder(order) 
{
    const response = await fetch(
        `${BaseAdrress}/Orders`,
        {
            method: "POST",
            headers: {
            "Content-Type": "application/json"
            },
            body: JSON.stringify(order)
        }
    );

    if (!response.ok)
    {
        console.error("Post request error:", response.statusText);
    }

    return response.ok
}

export async function getOrders(pagination, index) {
    const response = await fetch(`${BaseAdrress}/Orders/GetOrders?pagination=${pagination}&pageIndex=${index}`);
        
    return await response.json();
}