﻿using System;
using MvvmCross.Binding.iOS.Views;
using MyCompanyInThePocket.Core.ViewModels;
using UIKit;
using System.Linq;
using Foundation;

namespace MyCompanyInThePocket.iOS.Views
{
	public class MeetingsViewSource : MvxTableViewSource
	{
		private SuspendableObservableCollection<GroupedMeetingViewModel> GetGroupedData()
		{
			var source = ItemsSource as SuspendableObservableCollection<GroupedMeetingViewModel>;

			if (source == null)
			{
				return new SuspendableObservableCollection<GroupedMeetingViewModel>();
			}

			return source;
		}

		public MeetingsViewSource(UITableView tableView)
			: base(tableView)
		{
			tableView.RegisterClassForCellReuse(typeof(MeetingCell), MeetingCell.Key);
		}



		public override nint RowsInSection(UITableView tableview, nint section)
		{
			var groupedData = GetGroupedData();

			if (groupedData.Any())
			{
				var group = groupedData[(int)section];
				return group.Count;
			}

			return 0;
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			var count =  GetGroupedData().Count;

			return count;
		}

		public override string TitleForHeader(UITableView tableView, nint section)
		{
			var groupedData = GetGroupedData();

			return !groupedData.Any() ? string.Empty : groupedData[(int)section].Date.ToShortDateString();
		}

		public override nfloat EstimatedHeightForHeader(UITableView tableView, nint section)
		{
			return 20;
		}

		public override nfloat GetHeightForHeader(UITableView tableView, nint section)
		{
			return 20;
		}
	
		public override UIView GetViewForHeader(UITableView tableView, nint section)
		{
			var groupedData = GetGroupedData();
			return new MeetingCellHeaderView(groupedData[(int)section]);
		}

		protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
		{
			return (UITableViewCell)TableView.DequeueReusableCell(MeetingCell.Key, indexPath);
		}

		protected override object GetItemAt(NSIndexPath indexPath)
		{
			var groupedData = GetGroupedData();

			if (!groupedData.Any())
			{
				return null;
			}

			var group = groupedData[indexPath.Section];
			return group[indexPath.Row];
		}

		public override void WillDisplay(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
		{
			// On désactive la couleur blanche de fond de cellule
			cell.BackgroundColor = UIColor.Clear;
			cell.BackgroundView = null;
		}
	}
}
