﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF_Service_Server_
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TechMate_db")]
	public partial class linq2sqlDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertBuild(Build instance);
    partial void UpdateBuild(Build instance);
    partial void DeleteBuild(Build instance);
    partial void InsertComponent(Component instance);
    partial void UpdateComponent(Component instance);
    partial void DeleteComponent(Component instance);
    partial void InsertCartItem(CartItem instance);
    partial void UpdateCartItem(CartItem instance);
    partial void DeleteCartItem(CartItem instance);
    partial void InsertCart(Cart instance);
    partial void UpdateCart(Cart instance);
    partial void DeleteCart(Cart instance);
    #endregion
		
		public linq2sqlDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["TechMate_dbConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public linq2sqlDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linq2sqlDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linq2sqlDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linq2sqlDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Build> Builds
		{
			get
			{
				return this.GetTable<Build>();
			}
		}
		
		public System.Data.Linq.Table<Component> Components
		{
			get
			{
				return this.GetTable<Component>();
			}
		}
		
		public System.Data.Linq.Table<CartItem> CartItems
		{
			get
			{
				return this.GetTable<CartItem>();
			}
		}
		
		public System.Data.Linq.Table<Cart> Carts
		{
			get
			{
				return this.GetTable<Cart>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _name;
		
		private string _surname;
		
		private string _email;
		
		private string _cellNo;
		
		private string _gender;
		
		private string _password;
		
		private string _userType;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnsurnameChanging(string value);
    partial void OnsurnameChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OncellNoChanging(string value);
    partial void OncellNoChanged();
    partial void OngenderChanging(string value);
    partial void OngenderChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    partial void OnuserTypeChanging(string value);
    partial void OnuserTypeChanged();
    #endregion
		
		public User()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(MAX)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_surname", DbType="VarChar(MAX)")]
		public string surname
		{
			get
			{
				return this._surname;
			}
			set
			{
				if ((this._surname != value))
				{
					this.OnsurnameChanging(value);
					this.SendPropertyChanging();
					this._surname = value;
					this.SendPropertyChanged("surname");
					this.OnsurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cellNo", DbType="VarChar(MAX)")]
		public string cellNo
		{
			get
			{
				return this._cellNo;
			}
			set
			{
				if ((this._cellNo != value))
				{
					this.OncellNoChanging(value);
					this.SendPropertyChanging();
					this._cellNo = value;
					this.SendPropertyChanged("cellNo");
					this.OncellNoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gender", DbType="VarChar(MAX)")]
		public string gender
		{
			get
			{
				return this._gender;
			}
			set
			{
				if ((this._gender != value))
				{
					this.OngenderChanging(value);
					this.SendPropertyChanging();
					this._gender = value;
					this.SendPropertyChanged("gender");
					this.OngenderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_userType", DbType="VarChar(MAX)")]
		public string userType
		{
			get
			{
				return this._userType;
			}
			set
			{
				if ((this._userType != value))
				{
					this.OnuserTypeChanging(value);
					this.SendPropertyChanging();
					this._userType = value;
					this.SendPropertyChanged("userType");
					this.OnuserTypeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Build")]
	public partial class Build : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _category;
		
		private string _compatibilityStatus;
		
		private int _baseBuild_id;
		
		private System.Nullable<int> _user_id;
		
		private System.Nullable<int> _ram_id;
		
		private System.Nullable<int> _storage_id;
		
		private System.Nullable<int> _graphics_id;
		
		private System.Nullable<int> _cpu_id;
		
		private System.Nullable<int> _totalPrice;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OncategoryChanging(string value);
    partial void OncategoryChanged();
    partial void OncompatibilityStatusChanging(string value);
    partial void OncompatibilityStatusChanged();
    partial void OnbaseBuild_idChanging(int value);
    partial void OnbaseBuild_idChanged();
    partial void Onuser_idChanging(System.Nullable<int> value);
    partial void Onuser_idChanged();
    partial void Onram_idChanging(System.Nullable<int> value);
    partial void Onram_idChanged();
    partial void Onstorage_idChanging(System.Nullable<int> value);
    partial void Onstorage_idChanged();
    partial void Ongraphics_idChanging(System.Nullable<int> value);
    partial void Ongraphics_idChanged();
    partial void Oncpu_idChanging(System.Nullable<int> value);
    partial void Oncpu_idChanged();
    partial void OntotalPriceChanging(System.Nullable<int> value);
    partial void OntotalPriceChanged();
    #endregion
		
		public Build()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_category", DbType="VarChar(MAX)")]
		public string category
		{
			get
			{
				return this._category;
			}
			set
			{
				if ((this._category != value))
				{
					this.OncategoryChanging(value);
					this.SendPropertyChanging();
					this._category = value;
					this.SendPropertyChanged("category");
					this.OncategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_compatibilityStatus", DbType="VarChar(MAX)")]
		public string compatibilityStatus
		{
			get
			{
				return this._compatibilityStatus;
			}
			set
			{
				if ((this._compatibilityStatus != value))
				{
					this.OncompatibilityStatusChanging(value);
					this.SendPropertyChanging();
					this._compatibilityStatus = value;
					this.SendPropertyChanged("compatibilityStatus");
					this.OncompatibilityStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_baseBuild_id", DbType="Int NOT NULL")]
		public int baseBuild_id
		{
			get
			{
				return this._baseBuild_id;
			}
			set
			{
				if ((this._baseBuild_id != value))
				{
					this.OnbaseBuild_idChanging(value);
					this.SendPropertyChanging();
					this._baseBuild_id = value;
					this.SendPropertyChanged("baseBuild_id");
					this.OnbaseBuild_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", DbType="Int")]
		public System.Nullable<int> user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ram_id", DbType="Int")]
		public System.Nullable<int> ram_id
		{
			get
			{
				return this._ram_id;
			}
			set
			{
				if ((this._ram_id != value))
				{
					this.Onram_idChanging(value);
					this.SendPropertyChanging();
					this._ram_id = value;
					this.SendPropertyChanged("ram_id");
					this.Onram_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_storage_id", DbType="Int")]
		public System.Nullable<int> storage_id
		{
			get
			{
				return this._storage_id;
			}
			set
			{
				if ((this._storage_id != value))
				{
					this.Onstorage_idChanging(value);
					this.SendPropertyChanging();
					this._storage_id = value;
					this.SendPropertyChanged("storage_id");
					this.Onstorage_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_graphics_id", DbType="Int")]
		public System.Nullable<int> graphics_id
		{
			get
			{
				return this._graphics_id;
			}
			set
			{
				if ((this._graphics_id != value))
				{
					this.Ongraphics_idChanging(value);
					this.SendPropertyChanging();
					this._graphics_id = value;
					this.SendPropertyChanged("graphics_id");
					this.Ongraphics_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cpu_id", DbType="Int")]
		public System.Nullable<int> cpu_id
		{
			get
			{
				return this._cpu_id;
			}
			set
			{
				if ((this._cpu_id != value))
				{
					this.Oncpu_idChanging(value);
					this.SendPropertyChanging();
					this._cpu_id = value;
					this.SendPropertyChanged("cpu_id");
					this.Oncpu_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_totalPrice", DbType="Int")]
		public System.Nullable<int> totalPrice
		{
			get
			{
				return this._totalPrice;
			}
			set
			{
				if ((this._totalPrice != value))
				{
					this.OntotalPriceChanging(value);
					this.SendPropertyChanging();
					this._totalPrice = value;
					this.SendPropertyChanged("totalPrice");
					this.OntotalPriceChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Component")]
	public partial class Component : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _name;
		
		private string _price;
		
		private string _availability;
		
		private string _description;
		
		private string _image;
		
		private string _compatibility;
		
		private System.Nullable<int> _build_id;
		
		private string _category;
		
		private System.Nullable<int> _intPriceFormat;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnpriceChanging(string value);
    partial void OnpriceChanged();
    partial void OnavailabilityChanging(string value);
    partial void OnavailabilityChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    partial void OnimageChanging(string value);
    partial void OnimageChanged();
    partial void OncompatibilityChanging(string value);
    partial void OncompatibilityChanged();
    partial void Onbuild_idChanging(System.Nullable<int> value);
    partial void Onbuild_idChanged();
    partial void OncategoryChanging(string value);
    partial void OncategoryChanged();
    partial void OnintPriceFormatChanging(System.Nullable<int> value);
    partial void OnintPriceFormatChanged();
    #endregion
		
		public Component()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(MAX)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_price", DbType="VarChar(MAX)")]
		public string price
		{
			get
			{
				return this._price;
			}
			set
			{
				if ((this._price != value))
				{
					this.OnpriceChanging(value);
					this.SendPropertyChanging();
					this._price = value;
					this.SendPropertyChanged("price");
					this.OnpriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_availability", DbType="VarChar(MAX)")]
		public string availability
		{
			get
			{
				return this._availability;
			}
			set
			{
				if ((this._availability != value))
				{
					this.OnavailabilityChanging(value);
					this.SendPropertyChanging();
					this._availability = value;
					this.SendPropertyChanged("availability");
					this.OnavailabilityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="VarChar(MAX)")]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_image", DbType="VarChar(MAX)")]
		public string image
		{
			get
			{
				return this._image;
			}
			set
			{
				if ((this._image != value))
				{
					this.OnimageChanging(value);
					this.SendPropertyChanging();
					this._image = value;
					this.SendPropertyChanged("image");
					this.OnimageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_compatibility", DbType="VarChar(MAX)")]
		public string compatibility
		{
			get
			{
				return this._compatibility;
			}
			set
			{
				if ((this._compatibility != value))
				{
					this.OncompatibilityChanging(value);
					this.SendPropertyChanging();
					this._compatibility = value;
					this.SendPropertyChanged("compatibility");
					this.OncompatibilityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_build_id", DbType="Int")]
		public System.Nullable<int> build_id
		{
			get
			{
				return this._build_id;
			}
			set
			{
				if ((this._build_id != value))
				{
					this.Onbuild_idChanging(value);
					this.SendPropertyChanging();
					this._build_id = value;
					this.SendPropertyChanged("build_id");
					this.Onbuild_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_category", DbType="VarChar(MAX)")]
		public string category
		{
			get
			{
				return this._category;
			}
			set
			{
				if ((this._category != value))
				{
					this.OncategoryChanging(value);
					this.SendPropertyChanging();
					this._category = value;
					this.SendPropertyChanged("category");
					this.OncategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_intPriceFormat", DbType="Int")]
		public System.Nullable<int> intPriceFormat
		{
			get
			{
				return this._intPriceFormat;
			}
			set
			{
				if ((this._intPriceFormat != value))
				{
					this.OnintPriceFormatChanging(value);
					this.SendPropertyChanging();
					this._intPriceFormat = value;
					this.SendPropertyChanged("intPriceFormat");
					this.OnintPriceFormatChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CartItems")]
	public partial class CartItem : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Nullable<int> _component_id;
		
		private System.Nullable<int> _cart_id;
		
		private System.Nullable<int> _quantity;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void Oncomponent_idChanging(System.Nullable<int> value);
    partial void Oncomponent_idChanged();
    partial void Oncart_idChanging(System.Nullable<int> value);
    partial void Oncart_idChanged();
    partial void OnquantityChanging(System.Nullable<int> value);
    partial void OnquantityChanged();
    #endregion
		
		public CartItem()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_component_id", DbType="Int")]
		public System.Nullable<int> component_id
		{
			get
			{
				return this._component_id;
			}
			set
			{
				if ((this._component_id != value))
				{
					this.Oncomponent_idChanging(value);
					this.SendPropertyChanging();
					this._component_id = value;
					this.SendPropertyChanged("component_id");
					this.Oncomponent_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cart_id", DbType="Int")]
		public System.Nullable<int> cart_id
		{
			get
			{
				return this._cart_id;
			}
			set
			{
				if ((this._cart_id != value))
				{
					this.Oncart_idChanging(value);
					this.SendPropertyChanging();
					this._cart_id = value;
					this.SendPropertyChanged("cart_id");
					this.Oncart_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_quantity", DbType="Int")]
		public System.Nullable<int> quantity
		{
			get
			{
				return this._quantity;
			}
			set
			{
				if ((this._quantity != value))
				{
					this.OnquantityChanging(value);
					this.SendPropertyChanging();
					this._quantity = value;
					this.SendPropertyChanged("quantity");
					this.OnquantityChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Cart")]
	public partial class Cart : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _user_id;
		
		private int _build_id;
		
		private string _totalPrice;
		
		private string _totalDiscountSaved;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void Onbuild_idChanging(int value);
    partial void Onbuild_idChanged();
    partial void OntotalPriceChanging(string value);
    partial void OntotalPriceChanged();
    partial void OntotalDiscountSavedChanging(string value);
    partial void OntotalDiscountSavedChanged();
    #endregion
		
		public Cart()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", DbType="Int NOT NULL")]
		public int user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_build_id", DbType="Int NOT NULL")]
		public int build_id
		{
			get
			{
				return this._build_id;
			}
			set
			{
				if ((this._build_id != value))
				{
					this.Onbuild_idChanging(value);
					this.SendPropertyChanging();
					this._build_id = value;
					this.SendPropertyChanged("build_id");
					this.Onbuild_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_totalPrice", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string totalPrice
		{
			get
			{
				return this._totalPrice;
			}
			set
			{
				if ((this._totalPrice != value))
				{
					this.OntotalPriceChanging(value);
					this.SendPropertyChanging();
					this._totalPrice = value;
					this.SendPropertyChanged("totalPrice");
					this.OntotalPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_totalDiscountSaved", DbType="VarChar(MAX)")]
		public string totalDiscountSaved
		{
			get
			{
				return this._totalDiscountSaved;
			}
			set
			{
				if ((this._totalDiscountSaved != value))
				{
					this.OntotalDiscountSavedChanging(value);
					this.SendPropertyChanging();
					this._totalDiscountSaved = value;
					this.SendPropertyChanged("totalDiscountSaved");
					this.OntotalDiscountSavedChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
