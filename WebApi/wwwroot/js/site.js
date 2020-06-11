// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addToList() {
	if ($("#tmpForm").length != 0) {
		return;
	}
	tempNode = document.querySelector("form[enctype='multipart/form-data']").cloneNode(true); //true for deep clone
	tempNode.action = "/Catalogue/Create";
	tempNode.id = "tmpForm";
	tempNode.querySelector("div[class='form-group']").querySelector("img").src = "";
	tempNode.querySelector("div[class='container list-group']").querySelector("input").value = "";
	tempNode.querySelector("div[class='container list-group']").querySelector("textarea").value = "";
	tempNode.querySelector("div[class='container list-group']").querySelector("div").querySelector("div").innerHTML =
		"<input type='submit' value='Create' class='btn btn-success flex-grow-2' style='margin-right: 5px;' />" +
		"<buttun onclick='removeElement(\"tmpForm\")' type='submit' value='Delete' class='btn btn-danger flex-grow-2' >Delete</button>"
	$("#list").prepend(tempNode);
	setImgPreview();
}

function removeElement(id) {
	if (confirm("Are you sure?")) {
		var item = document.querySelector("[id='" + id + "']");
		var priceNode = item.querySelector("input[name='price']");
		var countNode = item.querySelector("input[class='form-control count']");
		if (priceNode != null && countNode != null) {
			var fullPriceNode = item.parentNode.parentNode.querySelector("h4[name='fullPrice']");
			if (fullPriceNode != null) {
				fullPriceNode.innerHTML = parseInt(fullPriceNode.innerHTML) -
					parseInt(priceNode.value) * parseInt(countNode.value);
			}
		}
		$("#" + id).remove();
	}
}

function recalcFullPrie(id) {
	var item = document.querySelector("div[id='" + id + "']").parentNode;
	var countItem = item.querySelector("input[class='form-control count']");
	var fullPriceItem = document.querySelector("h4[name='fullPrice']");

	var count = parseInt(countItem.value);
	fullPriceItem.innerHTML = price * count;
}

function addToOrder(id, src, name, price) {
	var idSelector = "#" + id;

	tempNode = document.querySelector("h4[name='fullPrice']");
	lastPrice = parseInt(tempNode.innerHTML)
	if (isNaN(lastPrice)) {
		lastPrice = 0;
	}
	tempNode.innerHTML = lastPrice + price;

	var item = document.querySelector("[id='" + id + "']");
	if (item != null) {
		var countItem = item.querySelector("input[class='form-control count']");
		countItem.value = parseInt(countItem.value) + 1;
		return;
	}
	tempNode = document.querySelector("div[class='list-group list-group-horizontal order-item']").cloneNode(true); //true for deep clone
	tempNode.id = id;
	tempNode.querySelector("img").src = src;
	tempNode.querySelector("h5").innerHTML = name;
	tempNode.querySelector("button").onclick = function () {
		removeElement(id);
	}

	var index = document.querySelector("div[class='list-group-item-action list-group-item order-list']").childElementCount - 1;

	var itemInput = tempNode.querySelector("input[class='item']");
	itemInput.name = 'Order.Items[' + index + '].Id';
	itemInput.value = id;

	var priceInput = tempNode.querySelector("input[name='price']");
	priceInput.value = price;

	var countInput = tempNode.querySelector("input[class='form-control count']");
	countInput.name = 'Order.Items[' + index + '].Count';
	countInput.value = 1;
	countInput.onchange = function () {
		recalcFullPrie(id);
	}

	$(".order-list").prepend(tempNode);
	$(idSelector).removeAttr('hidden');
}