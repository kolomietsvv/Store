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
		"<buttun onclick='removeFromList()' type='submit' value='Delete' class='btn btn-danger flex-grow-2' >Delete</button>"
	$("#list").prepend(tempNode);
	setImgPreview();
}

function removeFromList() {
	if (confirm("Are you sure?")) {
		$("#tmpForm").remove();
	}
}

function addToOrder(item) {
	var node = document.querySelector("div[name='Order']");
	var child = document.createElement('input');
	var nexIndex = node.childNodes.length - 1;
	child.name = "Order[" + nexIndex + "]";
	child.value = item;
	node.appendChild(child);

	var label = document.querySelector("h4[name='itemsCount']");
	label.innerHTML = node.childNodes.length;
}