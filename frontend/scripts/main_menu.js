const properties = [
    { id: 1, name: "Квартира в центре", price: 3000 },
    { id: 2, name: "Дом за городом", price: 7000 },
    { id: 3, name: "Студия у метро", price: 5000 },
    { id: 4, name: "Коттедж на берегу", price: 9000 },
    { id: 5, name: "Апартаменты в новом ЖК", price: 6000 },
];

function updatePriceValue(value) {
    const priceValueElement = document.getElementById("priceValue");
    if (priceValueElement) {
        priceValueElement.textContent = value + " тыс. руб";
    }
    filterProperties(value);
}


function filterProperties(maxPrice) {
    const propertyList = document.getElementById("propertyList");

    if (propertyList) {
        propertyList.innerHTML = '';

        properties.forEach(property => {
            if (property.price <= maxPrice) {
                const li = document.createElement("li");
                li.textContent = "${property.name} - ${property.price} тыс. руб.";
                propertyList.appendChild(li);
            }
        });
    } else {
        console.error('Элемент #propertyList не найден.');
    }
}

document.addEventListener('DOMContentLoaded', function () {
    filterProperties(5000);
});