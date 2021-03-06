﻿/*
    <JSGameIDE - An open-source IDE+Library to Javascript Game Development>
    Copyright (C) 2015  Patrick Pissurno

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, version 3, except for commercial usage,
    which is strictly FORBIDDEN.
   
    COMMERCIAL USAGE IS STRICTLY FORBIDDEN!
    
    If you're going to distribute a version of this program you need to
    keep this commentary in all the classes of it, and also you  should
    mantain it open source and under the same  terms  of  the  original
    version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See  the
    GNU General Public License for more details.

    You should have received a copy of  the  GNU  General Public  License
    along with this program.  If  not, see <http://www.gnu.org/licenses/>.
  
    For further  details see: http://patrickpissurno.github.io/JSGameIDE/
 */

/* This program  uses  a third-party  extension  for the JSON writing and
 * reading,  which was not developed  by  me: JSON.NET.  All the credits/
 * rights  of  this  extension are  of  its  author:  James  Newton-King.
 * This  extension is provided  without  ANY WARRANTY  and  any distribu-
 * tion  of it  should be  done with  its  own  license  and  terms.  For
 * further  details  about  JSON.NET  see: http://www.newtonsoft.com/json
 *                For more details about its license see: 
 * https://github.com/JamesNK/Newtonsoft.Json.Schema/blob/master/LICENSE.md
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace JSGameIDE
{
    public static class FileManager
    {
        public static MainForm mainForm;
        //Whether any unsaved modification is present
        private static bool unsavedChanges;
        public static bool UnsavedChanges
        {
            get { return unsavedChanges; }
            set
            {
                if (value)
                    mainForm.SetTitle(GameConfig.name + "*");
                else
                    mainForm.SetTitle(GameConfig.name);
                unsavedChanges = value;
            }
        }

        /// <summary>
        /// Saves the current project
        /// </summary>
        /// <param name="quiet">Whether the quiet mode is on or off</param>
        public static void Save(bool quiet = false)
        {
            try
            {
                JSGP package = new JSGP();
                package.name = GameConfig.name;
                package.gameWidth = GameConfig.width;
                package.gameHeight = GameConfig.height;
                package.viewWidth = GameConfig.viewWidth;
                package.viewHeight = GameConfig.viewHeight;
                package.rooms = Rooms.rooms.ToArray();
                package.roomAmount = Rooms.amount;
                package.roomFirstId = Rooms.firstId;
                package.sprites = Sprites.sprites.ToArray();
                package.spriteAmount = Sprites.amount;
                package.objects = Objects.objects.ToArray();
                package.objectAmount = Objects.amount;
                package.scripts = Scripts.scripts.ToArray();
                package.scriptAmount = Scripts.amount;
                string output = JsonConvert.SerializeObject(package);
                using (StreamWriter outfile = new StreamWriter(GameConfig.path + @"\project.JSGP"))
                {
                    outfile.Write(output);
                }
                if (!quiet)
                {
                    MessageBox.Show("Project saved successfully.");
                }
                FileManager.UnsavedChanges = false;
            }
            catch {
                if(!quiet)
                    MessageBox.Show("Saving error.");
            }
        }

        /// <summary>
        /// Loads a given project
        /// </summary>
        /// <param name="path">A string containing the path to the given project</param>
        public static void Load(string path,bool quiet = false)
        {
            bool run;
            if (!quiet)
            {
                DialogResult _res = MessageBox.Show("Save changes to the project?", "JSGameIDE", MessageBoxButtons.YesNoCancel);
                if (_res == DialogResult.Yes)
                    Save(true);
                run =  _res== DialogResult.Yes || _res == DialogResult.No;
            
            }
            else
                run = true;
            if (run)
            {
                try
                {
                    string input = "";
                    //Reads all the project data
                    using (StreamReader sr = new StreamReader(path))
                    {
                        input += sr.ReadToEnd();
                    }
                    //Parses the file (JSON)
                    var output2 = JsonConvert.DeserializeObject<dynamic>(input);
                    //Updates all the project data
                    GameConfig.name = (string)output2.name;
                    GameConfig.path = Path.GetDirectoryName(path);
                    GameConfig.width = (int)output2.gameWidth;
                    GameConfig.height = (int)output2.gameHeight;
                    GameConfig.viewWidth = (int)output2.viewWidth;
                    GameConfig.viewHeight = (int)output2.viewHeight;
                    Sprites.amount = (int)output2.spriteAmount;
                    Objects.amount = (int)output2.objectAmount;
                    Rooms.amount = (int)output2.roomAmount;
                    Rooms.firstId = (int)output2.roomFirstId;
                    Scripts.amount = (int)output2.scriptAmount;

                    //Loads the sprites
                    var _a = ((JArray)output2.sprites).ToObject<List<dynamic>>();
                    for (int i = 0; i < Sprites.amount; i++) { Sprites.sprites.Add(null); }
                    foreach (var _b in _a)
                    {
                        if (_b != null)
                        {
                            Sprite spr = new Sprite();
                            spr.name = (string)_b.name;
                            spr.id = (int)_b.id;
                            if (_b.path != null)
                            {
                                List<string> _path = new List<string>();
                                foreach (var _c in _b.path)
                                {
                                    _path.Add((string)_c);
                                }
                                spr.path = _path.ToArray<string>();
                            }
                            Sprites.sprites[spr.id] = spr;
                            TreeNode _node = new TreeNode(spr.name);
                            _node.Name = "" + spr.id;
                            spr.node = _node;
                            mainForm.AddViewNodeChild("Sprites", _node);
                        }
                    }

                    //Loads the objects
                    _a = ((JArray)output2.objects).ToObject<List<dynamic>>();
                    for (int i = 0; i < Objects.amount; i++) { Objects.objects.Add(null); }
                    foreach (var _b in _a)
                    {
                        if (_b != null)
                        {
                            Object obj = new Object();
                            obj.id = (int)_b.id;
                            obj.name = (string)_b.name;
                            obj.sprite = (int)_b.sprite;
                            obj.autoDraw = (bool)_b.autoDraw;
                            obj.onCreate = (string)_b.onCreate;
                            obj.onUpdate = (string)_b.onUpdate;
                            obj.onDraw = (string)_b.onDraw;
                            obj.onKeyPressed = (string)_b.onKeyPressed;
                            obj.onKeyReleased = (string)_b.onKeyReleased;
                            obj.onDestroy = (string)_b.onDestroy;
                            obj.onMousePressed = (string)_b.onMousePressed;
                            obj.onMouseReleased = (string)_b.onMouseReleased;
                            Objects.objects[obj.id]=obj;
                            TreeNode _node = new TreeNode(obj.name);
                            _node.Name = "" + obj.id;
                            obj.node = _node;
                            mainForm.AddViewNodeChild("Objects", _node);
                        }
                    }

                    //Loads the rooms
                    for (int i = 0; i < Rooms.amount; i++) { Rooms.rooms.Add(null); }
                    _a = ((JArray)output2.rooms).ToObject<List<dynamic>>();
                    foreach (var _b in _a)
                    {
                        if (_b != null)
                        {
                            Room room = new Room();
                            room.id = (int)_b.id;
                            room.name = (string)_b.name;
                            room.onCreate = (string)_b.onCreate;
                            room.onUpdate = (string)_b.onUpdate;
                            room.onDraw = (string)_b.onDraw;
                            room.onKeyPressed = (string)_b.onKeyPressed;
                            room.onKeyReleased = (string)_b.onKeyReleased;
                            if (_b.editorCreate != null)
                            {
                                List<EditorObject> _editorCreate = new List<EditorObject>();
                                foreach (var _c in _b.editorCreate)
                                {
                                    EditorObject _obj = new EditorObject((float)_c.x, (float)_c.y, (int)_c.id);
                                    _editorCreate.Add(_obj);
                                }
                                room.editorCreate = _editorCreate.ToArray<EditorObject>();
                            }
                            Rooms.rooms[room.id] = room;
                            TreeNode _node = new TreeNode(room.name);
                            _node.Name = "" + room.id;
                            room.node = _node;
                            mainForm.AddViewNodeChild("Rooms", _node);
                        }
                    }

                    //Loads the scripts
                    _a = ((JArray)output2.scripts).ToObject<List<dynamic>>();
                    for (int i = 0; i < Scripts.amount; i++) { Scripts.scripts.Add(null); }
                    foreach (var _b in _a)
                    {
                        if (_b != null)
                        {
                            Script script = new Script();
                            script.id = (int)_b.id;
                            script.name = (string)_b.name;
                            script.data = (string)_b.data;
                            Scripts.scripts[script.id] = script;
                            TreeNode _node = new TreeNode(script.name);
                            _node.Name = "" + script.id;
                            script.node = _node;
                            mainForm.AddViewNodeChild("Scripts", _node);
                        }
                    }
                    FileManager.UnsavedChanges = false;
                }
                catch
                {
                    MessageBox.Show("Can't open the file.");
                }
            }
        }
    }

    //The JSGP data package class
    public class JSGP
    {
        public string name;
        public int gameWidth;
        public int gameHeight;
        public int viewWidth;
        public int viewHeight;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Sprite[] sprites;
        public int spriteAmount;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Object[] objects;
        public int objectAmount;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Room[] rooms;
        public int roomAmount;
        public int roomFirstId;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Script[] scripts;
        public int scriptAmount;
    }


    public static class DirectoryExtension
    {
        //Directory copy extension
        public static void Copy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    Copy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
