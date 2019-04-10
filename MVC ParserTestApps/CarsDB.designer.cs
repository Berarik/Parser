﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_ParserTestApps
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="CDB")]
	public partial class CarsDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertCars(Cars instance);
    partial void UpdateCars(Cars instance);
    partial void DeleteCars(Cars instance);
    partial void InsertCarModels(CarModels instance);
    partial void UpdateCarModels(CarModels instance);
    partial void DeleteCarModels(CarModels instance);
    #endregion
		
		public CarsDBDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["CDBConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public CarsDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CarsDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CarsDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CarsDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Cars> Cars
		{
			get
			{
				return this.GetTable<Cars>();
			}
		}
		
		public System.Data.Linq.Table<CarModels> CarModels
		{
			get
			{
				return this.GetTable<CarModels>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Cars")]
	public partial class Cars : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _ModelId;
		
		private System.DateTime _Year;
		
		private decimal _Price;
		
		private string _Description;
		
		private EntityRef<CarModels> _CarModels;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnModelIdChanging(int value);
    partial void OnModelIdChanged();
    partial void OnYearChanging(System.DateTime value);
    partial void OnYearChanged();
    partial void OnPriceChanging(decimal value);
    partial void OnPriceChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public Cars()
		{
			this._CarModels = default(EntityRef<CarModels>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModelId", DbType="Int NOT NULL")]
		public int ModelId
		{
			get
			{
				return this._ModelId;
			}
			set
			{
				if ((this._ModelId != value))
				{
					if (this._CarModels.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnModelIdChanging(value);
					this.SendPropertyChanging();
					this._ModelId = value;
					this.SendPropertyChanged("ModelId");
					this.OnModelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Year", DbType="Date NOT NULL")]
		public System.DateTime Year
		{
			get
			{
				return this._Year;
			}
			set
			{
				if ((this._Year != value))
				{
					this.OnYearChanging(value);
					this.SendPropertyChanging();
					this._Year = value;
					this.SendPropertyChanged("Year");
					this.OnYearChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Money NOT NULL")]
		public decimal Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(150)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CarModels_Cars", Storage="_CarModels", ThisKey="ModelId", OtherKey="ModelId", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public CarModels CarModels
		{
			get
			{
				return this._CarModels.Entity;
			}
			set
			{
				CarModels previousValue = this._CarModels.Entity;
				if (((previousValue != value) 
							|| (this._CarModels.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._CarModels.Entity = null;
						previousValue.Cars.Remove(this);
					}
					this._CarModels.Entity = value;
					if ((value != null))
					{
						value.Cars.Add(this);
						this._ModelId = value.ModelId;
					}
					else
					{
						this._ModelId = default(int);
					}
					this.SendPropertyChanged("CarModels");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CarModels")]
	public partial class CarModels : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ModelId;
		
		private string _BrandName;
		
		private string _ModelName;
		
		private System.Nullable<System.DateTime> _YearStart;
		
		private string _CarId;
		
		private System.Nullable<System.DateTime> _YearEnd;
		
		private int _CarType;
		
		private EntitySet<Cars> _Cars;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnModelIdChanging(int value);
    partial void OnModelIdChanged();
    partial void OnBrandNameChanging(string value);
    partial void OnBrandNameChanged();
    partial void OnModelNameChanging(string value);
    partial void OnModelNameChanged();
    partial void OnYearStartChanging(System.Nullable<System.DateTime> value);
    partial void OnYearStartChanged();
    partial void OnCarIdChanging(string value);
    partial void OnCarIdChanged();
    partial void OnYearEndChanging(System.Nullable<System.DateTime> value);
    partial void OnYearEndChanged();
    partial void OnCarTypeChanging(int value);
    partial void OnCarTypeChanged();
    #endregion
		
		public CarModels()
		{
			this._Cars = new EntitySet<Cars>(new Action<Cars>(this.attach_Cars), new Action<Cars>(this.detach_Cars));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModelId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ModelId
		{
			get
			{
				return this._ModelId;
			}
			set
			{
				if ((this._ModelId != value))
				{
					this.OnModelIdChanging(value);
					this.SendPropertyChanging();
					this._ModelId = value;
					this.SendPropertyChanged("ModelId");
					this.OnModelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BrandName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string BrandName
		{
			get
			{
				return this._BrandName;
			}
			set
			{
				if ((this._BrandName != value))
				{
					this.OnBrandNameChanging(value);
					this.SendPropertyChanging();
					this._BrandName = value;
					this.SendPropertyChanged("BrandName");
					this.OnBrandNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModelName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string ModelName
		{
			get
			{
				return this._ModelName;
			}
			set
			{
				if ((this._ModelName != value))
				{
					this.OnModelNameChanging(value);
					this.SendPropertyChanging();
					this._ModelName = value;
					this.SendPropertyChanged("ModelName");
					this.OnModelNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_YearStart", DbType="Date")]
		public System.Nullable<System.DateTime> YearStart
		{
			get
			{
				return this._YearStart;
			}
			set
			{
				if ((this._YearStart != value))
				{
					this.OnYearStartChanging(value);
					this.SendPropertyChanging();
					this._YearStart = value;
					this.SendPropertyChanged("YearStart");
					this.OnYearStartChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CarId", DbType="NVarChar(50)")]
		public string CarId
		{
			get
			{
				return this._CarId;
			}
			set
			{
				if ((this._CarId != value))
				{
					this.OnCarIdChanging(value);
					this.SendPropertyChanging();
					this._CarId = value;
					this.SendPropertyChanged("CarId");
					this.OnCarIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_YearEnd", DbType="Date")]
		public System.Nullable<System.DateTime> YearEnd
		{
			get
			{
				return this._YearEnd;
			}
			set
			{
				if ((this._YearEnd != value))
				{
					this.OnYearEndChanging(value);
					this.SendPropertyChanging();
					this._YearEnd = value;
					this.SendPropertyChanged("YearEnd");
					this.OnYearEndChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CarType", DbType="Int NOT NULL")]
		public int CarType
		{
			get
			{
				return this._CarType;
			}
			set
			{
				if ((this._CarType != value))
				{
					this.OnCarTypeChanging(value);
					this.SendPropertyChanging();
					this._CarType = value;
					this.SendPropertyChanged("CarType");
					this.OnCarTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CarModels_Cars", Storage="_Cars", ThisKey="ModelId", OtherKey="ModelId")]
		public EntitySet<Cars> Cars
		{
			get
			{
				return this._Cars;
			}
			set
			{
				this._Cars.Assign(value);
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
		
		private void attach_Cars(Cars entity)
		{
			this.SendPropertyChanging();
			entity.CarModels = this;
		}
		
		private void detach_Cars(Cars entity)
		{
			this.SendPropertyChanging();
			entity.CarModels = null;
		}
	}
}
#pragma warning restore 1591