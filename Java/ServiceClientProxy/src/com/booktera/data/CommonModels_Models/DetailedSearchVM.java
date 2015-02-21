/**
 * DetailedSearchVM.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models;

public class DetailedSearchVM implements java.io.Serializable
{
	private com.booktera.data.CommonModels_Models.DetailedSearchVMDetailedSearchInputs	searchInputs;

	private com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM		searchResults;

	public DetailedSearchVM()
	{
	}

	public DetailedSearchVM(com.booktera.data.CommonModels_Models.DetailedSearchVMDetailedSearchInputs searchInputs,
			com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM searchResults)
	{
		this.searchInputs = searchInputs;
		this.searchResults = searchResults;
	}

	/**
	 * Gets the searchInputs value for this DetailedSearchVM.
	 * 
	 * @return searchInputs
	 */
	public com.booktera.data.CommonModels_Models.DetailedSearchVMDetailedSearchInputs getSearchInputs()
	{
		return searchInputs;
	}

	/**
	 * Sets the searchInputs value for this DetailedSearchVM.
	 * 
	 * @param searchInputs
	 */
	public void setSearchInputs(com.booktera.data.CommonModels_Models.DetailedSearchVMDetailedSearchInputs searchInputs)
	{
		this.searchInputs = searchInputs;
	}

	/**
	 * Gets the searchResults value for this DetailedSearchVM.
	 * 
	 * @return searchResults
	 */
	public com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM getSearchResults()
	{
		return searchResults;
	}

	/**
	 * Sets the searchResults value for this DetailedSearchVM.
	 * 
	 * @param searchResults
	 */
	public void setSearchResults(com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM searchResults)
	{
		this.searchResults = searchResults;
	}

	private java.lang.Object	__equalsCalc	= null;

	public synchronized boolean equals(java.lang.Object obj)
	{
		if (!(obj instanceof DetailedSearchVM))
			return false;
		DetailedSearchVM other = (DetailedSearchVM) obj;
		if (obj == null)
			return false;
		if (this == obj)
			return true;
		if (__equalsCalc != null)
		{
			return (__equalsCalc == obj);
		}
		__equalsCalc = obj;
		boolean _equals;
		_equals = true
				&& ((this.searchInputs == null && other.getSearchInputs() == null) || (this.searchInputs != null && this.searchInputs.equals(other
						.getSearchInputs())))
				&& ((this.searchResults == null && other.getSearchResults() == null) || (this.searchResults != null && this.searchResults.equals(other
						.getSearchResults())));
		__equalsCalc = null;
		return _equals;
	}

	private boolean	__hashCodeCalc	= false;

	public synchronized int hashCode()
	{
		if (__hashCodeCalc)
		{
			return 0;
		}
		__hashCodeCalc = true;
		int _hashCode = 1;
		if (getSearchInputs() != null)
		{
			_hashCode += getSearchInputs().hashCode();
		}
		if (getSearchResults() != null)
		{
			_hashCode += getSearchResults().hashCode();
		}
		__hashCodeCalc = false;
		return _hashCode;
	}

	// Type metadata
	private static org.apache.axis.description.TypeDesc	typeDesc	= new org.apache.axis.description.TypeDesc(DetailedSearchVM.class, true);

	static
	{
		typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "DetailedSearchVM"));
		org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
		elemField.setFieldName("searchInputs");
		elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "SearchInputs"));
		elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models",
				"DetailedSearchVM.DetailedSearchInputs"));
		elemField.setMinOccurs(0);
		elemField.setNillable(true);
		typeDesc.addFieldDesc(elemField);
		elemField = new org.apache.axis.description.ElementDesc();
		elemField.setFieldName("searchResults");
		elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "SearchResults"));
		elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "BookBlockPLVM"));
		elemField.setMinOccurs(0);
		elemField.setNillable(true);
		typeDesc.addFieldDesc(elemField);
	}

	/**
	 * Return type metadata object
	 */
	public static org.apache.axis.description.TypeDesc getTypeDesc()
	{
		return typeDesc;
	}

	/**
	 * Get Custom Serializer
	 */
	public static org.apache.axis.encoding.Serializer getSerializer(java.lang.String mechType, java.lang.Class _javaType, javax.xml.namespace.QName _xmlType)
	{
		return new org.apache.axis.encoding.ser.BeanSerializer(_javaType, _xmlType, typeDesc);
	}

	/**
	 * Get Custom Deserializer
	 */
	public static org.apache.axis.encoding.Deserializer getDeserializer(java.lang.String mechType, java.lang.Class _javaType, javax.xml.namespace.QName _xmlType)
	{
		return new org.apache.axis.encoding.ser.BeanDeserializer(_javaType, _xmlType, typeDesc);
	}

}
