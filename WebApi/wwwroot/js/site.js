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
		$("#" + id).remove();
	}
}

function addToOrder(id, src, name) {
	var idSelector = "#" + id;
	var item = document.querySelector("[id='" + id + "']");
	if (item != null) {
		var countItem = item.querySelector("input[name='count']");
		countItem.value = parseInt(countItem.value) + 1;
		return;
	}
	tempNode = document.querySelector("div[class='list-group list-group-horizontal order-item']").cloneNode(true); //true for deep clone
	tempNode.id = id;
	tempNode.querySelector("img").src = src;
	tempNode.querySelector("h5").innerHTML = name;
	tempNode.querySelector("input[name='count']").value = 1;
	tempNode.querySelector("button").onclick = function () {
		removeElement(id);
	}
	$(".order-list").prepend(tempNode);
	$(idSelector).removeAttr('hidden');
}