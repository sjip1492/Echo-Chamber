{
	"patcher" : 	{
		"fileversion" : 1,
		"appversion" : 		{
			"major" : 8,
			"minor" : 0,
			"revision" : 8,
			"architecture" : "x64",
			"modernui" : 1
		}
,
		"classnamespace" : "box",
		"rect" : [ 34.0, 56.0, 1061.0, 810.0 ],
		"bglocked" : 0,
		"openinpresentation" : 0,
		"default_fontsize" : 12.0,
		"default_fontface" : 0,
		"default_fontname" : "Arial",
		"gridonopen" : 1,
		"gridsize" : [ 15.0, 15.0 ],
		"gridsnaponopen" : 1,
		"objectsnaponopen" : 1,
		"statusbarvisible" : 2,
		"toolbarvisible" : 1,
		"lefttoolbarpinned" : 0,
		"toptoolbarpinned" : 0,
		"righttoolbarpinned" : 0,
		"bottomtoolbarpinned" : 0,
		"toolbars_unpinned_last_save" : 0,
		"tallnewobj" : 0,
		"boxanimatetime" : 200,
		"enablehscroll" : 1,
		"enablevscroll" : 1,
		"devicewidth" : 0.0,
		"description" : "",
		"digest" : "",
		"tags" : "",
		"style" : "",
		"subpatcher_template" : "",
		"boxes" : [ 			{
				"box" : 				{
					"id" : "obj-11",
					"maxclass" : "gain~",
					"multichannelvariant" : 0,
					"numinlets" : 1,
					"numoutlets" : 2,
					"outlettype" : [ "signal", "" ],
					"parameter_enable" : 0,
					"patching_rect" : [ 228.333339691162109, 365.666677117347717, 22.0, 140.0 ]
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-2",
					"maxclass" : "gain~",
					"multichannelvariant" : 0,
					"numinlets" : 1,
					"numoutlets" : 2,
					"outlettype" : [ "signal", "" ],
					"parameter_enable" : 0,
					"patching_rect" : [ 35.583333492279053, 346.666676998138428, 22.0, 140.0 ]
				}

			}
, 			{
				"box" : 				{
					"autosave" : 1,
					"bgmode" : 0,
					"border" : 0,
					"clickthrough" : 0,
					"id" : "obj-16",
					"maxclass" : "newobj",
					"numinlets" : 2,
					"numoutlets" : 8,
					"offset" : [ 0.0, 0.0 ],
					"outlettype" : [ "signal", "signal", "", "list", "int", "", "", "" ],
					"patching_rect" : [ 346.583333492279053, 696.0, 522.666673302650452, 249.333337783813477 ],
					"save" : [ "#N", "vst~", "loaduniqueid", 0, "SAFEReverb.vstinfo", ";" ],
					"saved_attribute_attributes" : 					{
						"valueof" : 						{
							"parameter_invisible" : 1,
							"parameter_longname" : "vst~[1]",
							"parameter_shortname" : "vst~",
							"parameter_type" : 3
						}

					}
,
					"saved_object_attributes" : 					{
						"parameter_enable" : 1,
						"parameter_mappable" : 0
					}
,
					"snapshot" : 					{
						"filetype" : "C74Snapshot",
						"version" : 2,
						"minorversion" : 0,
						"name" : "snapshotlist",
						"origin" : "vst~",
						"type" : "list",
						"subtype" : "Undefined",
						"embed" : 1,
						"snapshot" : 						{
							"pluginname" : "SAFEReverb.vstinfo",
							"plugindisplayname" : "SAFEReverb",
							"pluginsavedname" : "SAFEReverb",
							"pluginsaveduniqueid" : 0,
							"version" : 1,
							"isbank" : 0,
							"isbase64" : 1,
							"sliderorder" : [  ],
							"slidervisibility" : [ 1, 1, 1, 1, 1, 1, 1, 1, 1 ],
							"blob" : "255.CMlaKA....fQPMDZ....ALkQRYE..D.o....A.........................................vvVMjLgnK....OSEjQEIUY1UlbhMUYzQWZtc1bf.UXxEVakQWYxASOh.iHf.UXxEVakQWYxESOh.iK0HBHPElbg0VYzUlbxziHwHBHPElbg0VYzUlbyziHv3RMh.BTgIWXsUFckIGM8HBLh.BTgIWXsUFckIWM8HBLtTiHf.UXxEVakQWYxYSOhDiHf.UXxEVakQWYxcSOh.iKzLiLzLSM3PCLyXCNxbCL3bCMvHiHf.UXxEVakQWYxgSOh.iK2TiHu3C."
						}
,
						"snapshotlist" : 						{
							"current_snapshot" : 0,
							"entries" : [ 								{
									"filetype" : "C74Snapshot",
									"version" : 2,
									"minorversion" : 0,
									"name" : "SAFEReverb",
									"origin" : "SAFEReverb.vstinfo",
									"type" : "VST",
									"subtype" : "AudioEffect",
									"embed" : 0,
									"snapshot" : 									{
										"pluginname" : "SAFEReverb.vstinfo",
										"plugindisplayname" : "SAFEReverb",
										"pluginsavedname" : "SAFEReverb",
										"pluginsaveduniqueid" : 0,
										"version" : 1,
										"isbank" : 0,
										"isbase64" : 1,
										"sliderorder" : [  ],
										"slidervisibility" : [ 1, 1, 1, 1, 1, 1, 1, 1, 1 ],
										"blob" : "255.CMlaKA....fQPMDZ....ALkQRYE..D.o....A.........................................vvVMjLgnK....OSEjQEIUY1UlbhMUYzQWZtc1bf.UXxEVakQWYxASOh.iHf.UXxEVakQWYxESOh.iK0HBHPElbg0VYzUlbxziHwHBHPElbg0VYzUlbyziHv3RMh.BTgIWXsUFckIGM8HBLh.BTgIWXsUFckIWM8HBLtTiHf.UXxEVakQWYxYSOhDiHf.UXxEVakQWYxcSOh.iKzLiLzLSM3PCLyXCNxbCL3bCMvHiHf.UXxEVakQWYxgSOh.iK2TiHu3C."
									}
,
									"fileref" : 									{
										"name" : "SAFEReverb",
										"filename" : "SAFEReverb.maxsnap",
										"filepath" : "~/Documents/Max 8/Snapshots",
										"filepos" : -1,
										"snapshotfileid" : "7835976a91327a4b46c34c7728480517"
									}

								}
 ]
						}

					}
,
					"text" : "vst~ SAFEReverb.vstinfo",
					"varname" : "vst~[1]",
					"viewvisibility" : 1
				}

			}
, 			{
				"box" : 				{
					"autosave" : 1,
					"bgmode" : 0,
					"border" : 0,
					"clickthrough" : 0,
					"id" : "obj-15",
					"maxclass" : "newobj",
					"numinlets" : 2,
					"numoutlets" : 8,
					"offset" : [ 0.0, 0.0 ],
					"outlettype" : [ "signal", "signal", "", "list", "int", "", "", "" ],
					"patching_rect" : [ 35.583333492279053, 696.0, 321.333333969116211, 249.333337783813477 ],
					"save" : [ "#N", "vst~", "loaduniqueid", 0, "SAFEReverb.vstinfo", ";" ],
					"saved_attribute_attributes" : 					{
						"valueof" : 						{
							"parameter_invisible" : 1,
							"parameter_longname" : "vst~",
							"parameter_shortname" : "vst~",
							"parameter_type" : 3
						}

					}
,
					"saved_object_attributes" : 					{
						"parameter_enable" : 1,
						"parameter_mappable" : 0
					}
,
					"snapshot" : 					{
						"filetype" : "C74Snapshot",
						"version" : 2,
						"minorversion" : 0,
						"name" : "snapshotlist",
						"origin" : "vst~",
						"type" : "list",
						"subtype" : "Undefined",
						"embed" : 1,
						"snapshot" : 						{
							"pluginname" : "SAFEReverb.vstinfo",
							"plugindisplayname" : "SAFEReverb",
							"pluginsavedname" : "SAFEReverb",
							"pluginsaveduniqueid" : 0,
							"version" : 1,
							"isbank" : 0,
							"isbase64" : 1,
							"sliderorder" : [  ],
							"slidervisibility" : [ 1, 1, 1, 1, 1, 1, 1, 1, 1 ],
							"blob" : "255.CMlaKA....fQPMDZ....ALkQRYE..D.o....A.........................................vvVMjLgnK....OSEjQEIUY1UlbhMUYzQWZtc1bf.UXxEVakQWYxASOh.iHf.UXxEVakQWYxESOh.iK0HBHPElbg0VYzUlbxziHwHBHPElbg0VYzUlbyziHv3RMh.BTgIWXsUFckIGM8HBLh.BTgIWXsUFckIWM8HBLtTiHf.UXxEVakQWYxYSOhDiHf.UXxEVakQWYxcSOh.iKwTCLv.CLv.SM4XCLzXCMzbyM0PiHf.UXxEVakQWYxgSOh.iK2TiHu3C."
						}
,
						"snapshotlist" : 						{
							"current_snapshot" : 0,
							"entries" : [ 								{
									"filetype" : "C74Snapshot",
									"version" : 2,
									"minorversion" : 0,
									"name" : "SAFEReverb",
									"origin" : "SAFEReverb.vstinfo",
									"type" : "VST",
									"subtype" : "AudioEffect",
									"embed" : 0,
									"snapshot" : 									{
										"pluginname" : "SAFEReverb.vstinfo",
										"plugindisplayname" : "SAFEReverb",
										"pluginsavedname" : "SAFEReverb",
										"pluginsaveduniqueid" : 0,
										"version" : 1,
										"isbank" : 0,
										"isbase64" : 1,
										"sliderorder" : [  ],
										"slidervisibility" : [ 1, 1, 1, 1, 1, 1, 1, 1, 1 ],
										"blob" : "255.CMlaKA....fQPMDZ....ALkQRYE..D.o....A.........................................vvVMjLgnK....OSEjQEIUY1UlbhMUYzQWZtc1bf.UXxEVakQWYxASOh.iHf.UXxEVakQWYxESOh.iK0HBHPElbg0VYzUlbxziHwHBHPElbg0VYzUlbyziHv3RMh.BTgIWXsUFckIGM8HBLh.BTgIWXsUFckIWM8HBLtTiHf.UXxEVakQWYxYSOhDiHf.UXxEVakQWYxcSOh.iKwTCLv.CLv.SM4XCLzXCMzbyM0PiHf.UXxEVakQWYxgSOh.iK2TiHu3C."
									}
,
									"fileref" : 									{
										"name" : "SAFEReverb",
										"filename" : "SAFEReverb.maxsnap",
										"filepath" : "~/Documents/Max 8/Snapshots",
										"filepos" : -1,
										"snapshotfileid" : "7835976a91327a4b46c34c7728480517"
									}

								}
 ]
						}

					}
,
					"text" : "vst~ SAFEReverb.vstinfo",
					"varname" : "vst~",
					"viewvisibility" : 1
				}

			}
, 			{
				"box" : 				{
					"bgmode" : 0,
					"border" : 0,
					"clickthrough" : 0,
					"enablehscroll" : 0,
					"enablevscroll" : 0,
					"id" : "obj-10",
					"lockeddragscroll" : 0,
					"maxclass" : "bpatcher",
					"name" : "pitchShifterBP.maxpat",
					"numinlets" : 3,
					"numoutlets" : 1,
					"offset" : [ 0.0, 0.0 ],
					"outlettype" : [ "signal" ],
					"patching_rect" : [ 271.583333492279053, 517.0, 226.0, 169.0 ],
					"varname" : "pitchShifterBP",
					"viewvisibility" : 1
				}

			}
, 			{
				"box" : 				{
					"bgmode" : 0,
					"border" : 0,
					"clickthrough" : 0,
					"enablehscroll" : 0,
					"enablevscroll" : 0,
					"id" : "obj-9",
					"lockeddragscroll" : 0,
					"maxclass" : "bpatcher",
					"name" : "pitchShifterBP.maxpat",
					"numinlets" : 3,
					"numoutlets" : 1,
					"offset" : [ 0.0, 0.0 ],
					"outlettype" : [ "signal" ],
					"patching_rect" : [ 35.583333492279053, 517.0, 226.0, 169.0 ],
					"varname" : "pitchShifterBP[1]",
					"viewvisibility" : 1
				}

			}
, 			{
				"box" : 				{
					"bgmode" : 0,
					"border" : 0,
					"clickthrough" : 0,
					"enablehscroll" : 0,
					"enablevscroll" : 0,
					"id" : "obj-7",
					"lockeddragscroll" : 0,
					"maxclass" : "bpatcher",
					"name" : "PEC_UI.maxpat",
					"numinlets" : 0,
					"numoutlets" : 0,
					"offset" : [ 0.0, 0.0 ],
					"patching_rect" : [ 324.0, 23.0, 617.0, 440.0 ],
					"viewvisibility" : 1
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-4",
					"maxclass" : "message",
					"numinlets" : 2,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 35.583333492279053, 71.0, 35.0, 22.0 ],
					"text" : "open"
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-17",
					"maxclass" : "newobj",
					"numinlets" : 2,
					"numoutlets" : 0,
					"patching_rect" : [ 35.583333492279053, 982.000004768371582, 255.0, 22.0 ],
					"text" : "dac~ 1 2"
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-8",
					"maxclass" : "message",
					"numinlets" : 2,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 112.083333492279053, 34.0, 50.0, 22.0 ],
					"text" : "6"
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-6",
					"maxclass" : "comment",
					"numinlets" : 1,
					"numoutlets" : 0,
					"patching_rect" : [ 168.083333492279053, 36.0, 150.0, 20.0 ],
					"text" : "= num channels for adc"
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-1",
					"maxclass" : "newobj",
					"numinlets" : 0,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 37.083333492279053, 34.0, 69.0, 22.0 ],
					"text" : "r num_outs"
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-5",
					"maxclass" : "newobj",
					"numinlets" : 1,
					"numoutlets" : 12,
					"outlettype" : [ "signal", "signal", "signal", "signal", "signal", "signal", "signal", "signal", "signal", "signal", "signal", "signal" ],
					"patching_rect" : [ 35.583333492279053, 100.333336591720581, 254.999999999999943, 22.0 ],
					"presentation" : 1,
					"presentation_rect" : [ 685.666666746139526, 31.333336591720581, 253.999999999999943, 22.0 ],
					"text" : "adc~ 1 2 3 4 5 6 7 8 9 10 11 12"
				}

			}
, 			{
				"box" : 				{
					"channels" : 12,
					"id" : "obj-3",
					"lastchannelcount" : 0,
					"maxclass" : "live.gain~",
					"numinlets" : 12,
					"numoutlets" : 15,
					"outlettype" : [ "signal", "signal", "signal", "signal", "signal", "signal", "signal", "signal", "signal", "signal", "signal", "signal", "", "float", "list" ],
					"parameter_enable" : 1,
					"patching_rect" : [ 35.583333492279053, 149.333336591720581, 255.0, 166.0 ],
					"presentation" : 1,
					"presentation_rect" : [ 685.583333492279053, 79.333336591720581, 255.0, 166.0 ],
					"saved_attribute_attributes" : 					{
						"valueof" : 						{
							"parameter_mmax" : 6.0,
							"parameter_shortname" : "live.gain~",
							"parameter_type" : 0,
							"parameter_unitstyle" : 4,
							"parameter_mmin" : -70.0,
							"parameter_longname" : "live.gain~"
						}

					}
,
					"varname" : "live.gain~"
				}

			}
 ],
		"lines" : [ 			{
				"patchline" : 				{
					"destination" : [ "obj-8", 1 ],
					"source" : [ "obj-1", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-16", 0 ],
					"source" : [ "obj-10", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-10", 0 ],
					"source" : [ "obj-11", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-17", 0 ],
					"source" : [ "obj-15", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-17", 1 ],
					"source" : [ "obj-16", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-9", 0 ],
					"source" : [ "obj-2", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-11", 0 ],
					"source" : [ "obj-3", 1 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-2", 0 ],
					"source" : [ "obj-3", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-5", 0 ],
					"source" : [ "obj-4", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-3", 11 ],
					"source" : [ "obj-5", 11 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-3", 10 ],
					"source" : [ "obj-5", 10 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-3", 9 ],
					"source" : [ "obj-5", 9 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-3", 8 ],
					"source" : [ "obj-5", 8 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-3", 7 ],
					"source" : [ "obj-5", 7 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-3", 6 ],
					"source" : [ "obj-5", 6 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-3", 5 ],
					"source" : [ "obj-5", 5 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-3", 4 ],
					"source" : [ "obj-5", 4 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-3", 3 ],
					"source" : [ "obj-5", 3 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-3", 2 ],
					"source" : [ "obj-5", 2 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-3", 1 ],
					"source" : [ "obj-5", 1 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-3", 0 ],
					"source" : [ "obj-5", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-15", 0 ],
					"source" : [ "obj-9", 0 ]
				}

			}
 ],
		"parameters" : 		{
			"obj-16" : [ "vst~[1]", "vst~", 0 ],
			"obj-15" : [ "vst~", "vst~", 0 ],
			"obj-3" : [ "live.gain~", "live.gain~", 0 ],
			"parameterbanks" : 			{

			}

		}
,
		"dependency_cache" : [ 			{
				"name" : "PEC_UI.maxpat",
				"bootpath" : "~/UBC/MUSC 420/MVP/MaxMSP",
				"patcherrelativepath" : ".",
				"type" : "JSON",
				"implicit" : 1
			}
, 			{
				"name" : "pitchShifterBP.maxpat",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/Modules/Effects/pitchShifter",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/Modules/Effects/pitchShifter",
				"type" : "JSON",
				"implicit" : 1
			}
, 			{
				"name" : "info.png",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"type" : "PNG",
				"implicit" : 1
			}
, 			{
				"name" : "pShifter.maxpat",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/Modules/Effects/pitchShifter/lib",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/Modules/Effects/pitchShifter/lib",
				"type" : "JSON",
				"implicit" : 1
			}
, 			{
				"name" : "gizmoKH.maxpat",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/Modules/Effects/pitchShifter/lib",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/Modules/Effects/pitchShifter/lib",
				"type" : "JSON",
				"implicit" : 1
			}
, 			{
				"name" : "mixKH.abs.maxpat",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"type" : "JSON",
				"implicit" : 1
			}
, 			{
				"name" : "gainScale.maxpat",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"type" : "JSON",
				"implicit" : 1
			}
, 			{
				"name" : "lineKH.maxpat",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"type" : "JSON",
				"implicit" : 1
			}
, 			{
				"name" : "MRrC.maxpat",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"type" : "JSON",
				"implicit" : 1
			}
, 			{
				"name" : "multiName_.maxpat",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"type" : "JSON",
				"implicit" : 1
			}
, 			{
				"name" : "multiNameNonZero.maxpat",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"type" : "JSON",
				"implicit" : 1
			}
, 			{
				"name" : "pShiftInfo.maxpat",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/Modules/Effects/pitchShifter/lib",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/Modules/Effects/pitchShifter/lib",
				"type" : "JSON",
				"implicit" : 1
			}
, 			{
				"name" : "WetDrySlider4.png",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"type" : "PNG",
				"implicit" : 1
			}
, 			{
				"name" : "wetDryKnob2.png",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"type" : "PNG",
				"implicit" : 1
			}
, 			{
				"name" : "spiral01.png",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"type" : "PNG",
				"implicit" : 1
			}
, 			{
				"name" : "muter.maxpat",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"type" : "JSON",
				"implicit" : 1
			}
, 			{
				"name" : "MRr_.maxpat",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"type" : "JSON",
				"implicit" : 1
			}
, 			{
				"name" : "nTbp_.maxpat",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/ubcLib",
				"type" : "JSON",
				"implicit" : 1
			}
, 			{
				"name" : "powerButton03.png",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"type" : "PNG",
				"implicit" : 1
			}
, 			{
				"name" : "sliderTrack6.png",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"type" : "PNG",
				"implicit" : 1
			}
, 			{
				"name" : "sliderKnob3.png",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"type" : "PNG",
				"implicit" : 1
			}
, 			{
				"name" : "ol.pngknob.js",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"type" : "TEXT",
				"implicit" : 1
			}
, 			{
				"name" : "write01.png",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"type" : "PNG",
				"implicit" : 1
			}
, 			{
				"name" : "read01.png",
				"bootpath" : "~/Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"patcherrelativepath" : "../../../../Documents/Max 8/Library/UBCToolbox_1.05/picts",
				"type" : "PNG",
				"implicit" : 1
			}
, 			{
				"name" : "SAFEReverb.maxsnap",
				"bootpath" : "~/Documents/Max 8/Snapshots",
				"patcherrelativepath" : "../../../../Documents/Max 8/Snapshots",
				"type" : "mx@s",
				"implicit" : 1
			}
, 			{
				"name" : "OSC-route.mxo",
				"type" : "iLaX"
			}
 ],
		"autosave" : 0
	}

}
