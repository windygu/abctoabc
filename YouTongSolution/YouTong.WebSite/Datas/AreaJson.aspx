<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaJson.aspx.cs" Inherits="YouTong.WebSite.Datas.AreaJson" EnableViewState="false" %>

<%@ OutputCache VaryByParam="none" Duration="300" %>

var areas=<%= json %>;

function getRootAreas() {
	var childs = new Array();
	for(i=0;i<areas.length;i++) {
		if(areas[i].ParentID == 0) {
			childs.push(areas[i]);
		}
	}
	return childs;
}

function getChildAreas(id) {
	var childs = new Array();
	for(i=0;i<areas.length;i++) {
		if(areas[i].ParentID == id) {
			childs.push(areas[i]);
		}
	}
	return childs;
}