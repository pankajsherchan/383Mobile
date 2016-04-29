function shoppingCart(cartName) {
    this.cartName = cartName;
    this.clearCart = false;
    this.checkoutParameters = {};
    this.items = [];
    var jsonFile = this.createJSON;

    this.loadItems();

    var self = this;
    $(window).unload(function () {
        if (self.clearCart) {
            self.clearItems();
        }
        self.saveItems();
        self.clearCart = false;
    });
}

shoppingCart.prototype.loadItems = function () {
    var items = localStorage != null ? localStorage[this.cartName + "_items"] : null;
    if (items != null && JSON != null) {
        try {
            var items = JSON.parse(items);
            for (var i = 0; i < items.length; i++) {
                var item = items[i];
                if (item.Id != null && item.Name != null && item.price != null && item.inventoryCount != null) {
                    item = new cartItem(item.Id, item.Name, item.price, item.inventoryCount, item.type, item.time);
                    this.items.push(item);
                }
            }
        }
        catch (err) {
            // ignore errors while loading...
        }
    }
}

// save items to local storage
shoppingCart.prototype.saveItems = function () {
    if (localStorage != null && JSON != null) {
        localStorage[this.cartName + "_items"] = JSON.stringify(this.items);
    }
}


// adds an item to the cart
shoppingCart.prototype.addItem = function (Id, Name, price, quantity, type, time) {
    quantity = this.toNumber(quantity);
    if (quantity != 0) {

        // update quantity for existing item
        var found = false;
        for (var i = 0; i < this.items.length && !found; i++) {
            var item = this.items[i];
            if (item.Id == Id && item.price == price && item.time == time) {
                found = true;
                item.inventoryCount = this.toNumber(item.inventoryCount + quantity);
                if (item.inventoryCount <= 0) {
                    this.items.splice(i, 1);
                }
            }
        }

        // new item, add now
        if (!found) {
            var item = new cartItem(Id, Name, price, quantity, type, time);
            this.items.push(item);
        }

        // save changes
        this.saveItems();
    }
}

// get the total price for all items currently in the cart
shoppingCart.prototype.getTotalPrice = function (Id) {
    var total = 0;
    for (var i = 0; i < this.items.length; i++) {
        var item = this.items[i];
        if (Id == null || item.Id == Id) {
            total += this.toNumber(item.inventoryCount * item.price);
        }
    }
    return total;
}

// get the total price for all items currently in the cart
shoppingCart.prototype.getTotalCount = function (Id, starttime) {
    var count = 0;
    for (var i = 0; i < this.items.length; i++) {
        var item = this.items[i];
        if (Id == null || item.Id == Id && item.time == starttime) {
            count += this.toNumber(item.inventoryCount);
        }
    }
    return count;
}

// clear the cart
shoppingCart.prototype.clearItems = function () {
    this.items = [];
    this.saveItems();
}

// define checkout parameters
shoppingCart.prototype.addCheckoutParameters = function (serviceName, options) {

    // save parameters
    this.checkoutParameters[serviceName] = new checkoutParameters(serviceName, options);
}

// check out
shoppingCart.prototype.checkout = function (serviceName, clearCart, quantity) {

    // select serviceName if we have to
    if (serviceName == null) {
        var p = this.checkoutParameters[Object.keys(this.checkoutParameters)[0]];
        serviceName = p.serviceName;
    }

    // go to work
    var parms = this.checkoutParameters[serviceName];
    this.checkoutPurchase(parms, clearCart);
}

shoppingCart.prototype.checkoutPurchase = function (parms, clearCart) {

    //$http.put("http://localhost:58198/api/Products/", this.items)
    this.clearItems();
    //$scope.store.products = data.data;

}
shoppingCart.prototype.toNumber = function (value) {
    value = value * 1;
    return isNaN(value) ? 0 : value;
}

//----------------------------------------------------------------
// checkout parameters (one per supported payment service)
//
function checkoutParameters(serviceName, options) {
    this.serviceName = serviceName;
    this.options = options;
}

//----------------------------------------------------------------
// items in the cart
//
function cartItem(Id, Name, price, quantity, type, time) {
    this.Id = Id;
    this.Name = Name;
    this.price = price * 1;
    this.inventoryCount = quantity * 1;
    this.type = type;
    this.time = time;
}

